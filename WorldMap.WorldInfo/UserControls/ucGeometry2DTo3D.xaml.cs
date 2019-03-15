using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WorldMap.WorldInfo
{
    /// <summary>
    /// Interaction logic for ucGeometry2DTo3D.xaml
    /// </summary>
    public partial class ucGeometry2DTo3D : UserControl
    {
        #region Properties and Variables

        static float k;
        List<POINT2D> cArrJigar;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private delegate void UpdateMyLabelDelegatedelegate(float i);
        private delegate void UpdateMyGridDelegatedelegate(List<POINT2D> listTemp);

        public struct POINT2D
        {
            public float x;
            public float y;
        }

        public struct POINT3D
        {
            public float x;
            public float y;
            public float z;
        }

        public struct st2DInfo
        {
            public float fAngle;
            public float fHeight;
            public float fRad;
        }

        double dCenterScreenX;
        double dCenterScreenY;

        #endregion

        #region Constructor

        public ucGeometry2DTo3D()
        {
            InitializeComponent();

            dCenterScreenX = System.Windows.SystemParameters.PrimaryScreenWidth / 2;
            dCenterScreenY = System.Windows.SystemParameters.PrimaryScreenHeight / 2;

            CreateSquare();
            k = 0.0f;
            //CreateALine();

            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        #endregion

        #region Methods

        float GetClosedPolygonArea(List<POINT3D> cArrInput, int iSize)
        {
            if (iSize < 3)
                return 0.0f;

            int i = 0;
            float fArea = 0.0f;

            for (i = 0; i < iSize - 1; i++)
            {
                fArea += (cArrInput[i].x * cArrInput[i + 1].y - cArrInput[i + 1].x * cArrInput[i].y);
            }

            fArea += (cArrInput[iSize - 1].x * cArrInput[0].y - cArrInput[0].x * cArrInput[iSize - 1].y);

            fArea = Math.Abs(fArea / 2.0f);

            return fArea;

        }
        
        float GetClosedPolygonArea(List<POINT2D> cArrInput, int iSize)
        {
            if (iSize < 3)
                return 0.0f;

            int i = 0;
            float fArea = 0.0f;

            for (i = 0; i < iSize - 1; i++)
            {
                fArea += (cArrInput[i].x * cArrInput[i + 1].y - cArrInput[i + 1].x * cArrInput[i].y);
            }

            fArea += (cArrInput[iSize - 1].x * cArrInput[0].y - cArrInput[0].x * cArrInput[iSize - 1].y);

            fArea = Math.Abs(fArea / 2.0f);

            return fArea;

        }

        void GetClosedPolygonCentroid(List<POINT3D> cArrInput, int iSize, ref POINT2D ptCentroid)
        {
            int i = 0;
            float fArea = GetClosedPolygonArea(cArrInput, iSize);

            float fSumX = 0.0f;
            float fSumY = 0.0f;
            for (i = 0; i < iSize - 1; i++)
            {
                fSumX += (cArrInput[i].x + cArrInput[i + 1].x) * (cArrInput[i].x * cArrInput[i + 1].y - cArrInput[i + 1].x * cArrInput[i].y);
                fSumY += (cArrInput[i].y + cArrInput[i + 1].y) * (cArrInput[i].x * cArrInput[i + 1].y - cArrInput[i + 1].x * cArrInput[i].y);
            }

            fSumX += (cArrInput[iSize - 1].x + cArrInput[0].x) * (cArrInput[iSize - 1].x * cArrInput[0].y - cArrInput[0].x * cArrInput[iSize - 1].y);
            fSumY += (cArrInput[iSize - 1].y + cArrInput[0].y) * (cArrInput[iSize - 1].x * cArrInput[0].y - cArrInput[0].x * cArrInput[iSize - 1].y);

            ptCentroid.x = fSumX / (fArea * 6);
            ptCentroid.y = fSumY / (fArea * 6);
        }

        void GetClosedPolygonCentroid(List<POINT2D> cArrInput, int iSize, ref POINT2D ptCentroid)
        {
            int i = 0;
            float fArea = GetClosedPolygonArea(cArrInput, iSize);

            float fSumX = 0.0f;
            float fSumY = 0.0f;
            for (i = 0; i < iSize - 1; i++)
            {
                fSumX += (cArrInput[i].x + cArrInput[i + 1].x) * (cArrInput[i].x * cArrInput[i + 1].y - cArrInput[i + 1].x * cArrInput[i].y);
                fSumY += (cArrInput[i].y + cArrInput[i + 1].y) * (cArrInput[i].x * cArrInput[i + 1].y - cArrInput[i + 1].x * cArrInput[i].y);
            }

            fSumX += (cArrInput[iSize - 1].x + cArrInput[0].x) * (cArrInput[iSize - 1].x * cArrInput[0].y - cArrInput[0].x * cArrInput[iSize - 1].y);
            fSumY += (cArrInput[iSize - 1].y + cArrInput[0].y) * (cArrInput[iSize - 1].x * cArrInput[0].y - cArrInput[0].x * cArrInput[iSize - 1].y);

            ptCentroid.x = fSumX / (fArea * 6);
            ptCentroid.y = fSumY / (fArea * 6);
        }

        static POINT2D RotatePoint(POINT2D pointToRotate, POINT2D centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new POINT2D
            {
                x = (float)(cosTheta * (pointToRotate.x - centerPoint.x) - sinTheta * (pointToRotate.y - centerPoint.y) + centerPoint.x),
                y = (float)(sinTheta * (pointToRotate.x - centerPoint.x) + cosTheta * (pointToRotate.y - centerPoint.y) + centerPoint.y)
            };
        }

        public void CreateSquare()
        {
            List<POINT2D> listPoint2D = new List<POINT2D>();
            POINT2D point2D;
            point2D.x = 0;
            point2D.y = 0;
            listPoint2D.Add(point2D);

            point2D.x = 100;
            point2D.y = 0;
            listPoint2D.Add(point2D);

            point2D.x = 100;
            point2D.y = 100;
            listPoint2D.Add(point2D);

            point2D.x = 0;
            point2D.y = 100;
            listPoint2D.Add(point2D);

            point2D.x = 0;
            point2D.y = 0;
            listPoint2D.Add(point2D);

            POINT2D ptCentroid;
            ptCentroid.x = 0.0f;
            ptCentroid.y = 0.0f;
            GetClosedPolygonCentroid(listPoint2D, listPoint2D.Count, ref ptCentroid);

            POINT2D ptTemp;
            cArrJigar = new List<POINT2D>();
            foreach (var item in listPoint2D)
            {

                ptTemp.x = (float)(dCenterScreenX) + ptCentroid.x - item.x/*cArrOutput[400].x*/;
                ptTemp.y = (float)(dCenterScreenY) + ptCentroid.y - item.y/*cArrOutput[400].y*/;
                cArrJigar.Add(ptTemp);
            }

            //DrawLines(listPoint2D, gridMain);
            DrawLines(cArrJigar, gridMain);

            GetClosedPolygonCentroid(cArrJigar, cArrJigar.Count, ref ptCentroid);

            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Blue;

            Line line = new Line();
            line.X1 = (int)(dCenterScreenX);
            line.Y1 = (int)(dCenterScreenY);
            line.X2 = (int)(dCenterScreenX);
            line.Y2 = 0;
            line.StrokeThickness = 4;
            line.Stroke = redBrush;
            gridMain.Children.Add(line);

        }

        public void DrawLines(List<POINT2D> cArrLines, Grid uiElement)
        {
            gridMain.Children.Clear();

            for (int i = 0; i < cArrLines.Count - 1; i++)
            {
                SolidColorBrush redBrush = new SolidColorBrush();
                redBrush.Color = Colors.Red;

                Line line = new Line();
                line.X1 = cArrLines[i].x;
                line.Y1 = cArrLines[i].y;
                line.X2 = cArrLines[i + 1].x;
                line.Y2 = cArrLines[i + 1].y;
                line.StrokeThickness = 4;
                line.Stroke = redBrush;
                uiElement.Children.Add(line);
            }
        }

        private void MyFunction()
        {
            string lines_out;
            System.IO.StreamWriter file = new System.IO.StreamWriter("E:/abc.txt");

            for (float m = 0.0f; m < 361.0f; m += 1.8f)
            {
                POINT2D centroid;
                centroid.x = 683;
                centroid.y = 384;

                List<POINT2D> listTemp = new List<POINT2D>();

                float minX = 100000.0f;
                for (int i = 0; i < cArrJigar.Count; i += 1) //  for each file
                {
                    listTemp.Add(RotatePoint(cArrJigar[i], centroid, m));

                    if (listTemp[i].x < minX)
                    {
                        minX = listTemp[i].x;
                    }
                }

                //minX = 684.0f - minX;

                UpdateMyLabelDelegatedelegate UpdateMyDelegate = new UpdateMyLabelDelegatedelegate(UpdateMyDelegateLabel);
                UpdateMyGridDelegatedelegate UpdateMytestDelegate = new UpdateMyGridDelegatedelegate(UpdateMytestDelegateGrid);
                lblAngle.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, UpdateMyDelegate, m);
                gridMain.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, UpdateMytestDelegate, listTemp);
                System.Threading.Thread.Sleep(50);

                lines_out = String.Format("{0} {1} {2}\n", m, 1.0f, minX);
                file.WriteLine(lines_out);
            }
            file.Close();
        }

        private void UpdateMyDelegateLabel(float i)
        {
            lblAngle.Content = "angle:" + i.ToString();
        }

        private void UpdateMytestDelegateGrid(List<POINT2D> listTemp)
        {
            DrawLines(listTemp, gridMain);
        }

        private List<string> GetFileData()
        {
            const string f = "E://abc.txt";

            List<string> lines = new List<string>();

            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        lines.Add(line);
                    }

                }
            }

            return lines;

        }

        public float TanInverse(float x, float y)
        {
            //Commented due to small function and too many calls
            //FuncTracer fObjFuncTracer("GENERAL::CAWDllGeneral_01::TanInverse");
            float t;

            if (x == 0.0f && y > 0.0f)
            {
                return 90.0f;
            }
            else if (x == 0.0f && y < 0.0f)
            {
                return 270.0f;
            }
            else if (y == 0.0f)
            {
                if (x >= 0.0f)
                    return 0.0f;
                else if (x < 0.0f)
                    return 180.0f;
            }

            t = (float)(Math.Atan(Math.Abs(y / x)) * 180 / Math.PI);


            if (x < 0.0f && y > 0.0f)
                t = 180 - t;
            else if (y < 0.0f && x < 0.0f)
                t = 180 + t;
            else if (x > 0.0f && y < 0.0f)
                t = 360 - t;


            if (t < 0.0f)
            {
                //int k=10;
                MessageBox.Show("CGenMaths: TanInverse Error");
            }
            return t;
        }

        public float FindDisBtPt(float[] p, float[] p1, bool b3DDis)
        {
            //Commented due to small funct and too many call
            if (b3DDis)
                return ((float)Math.Sqrt(((p[0] - p1[0]) * (p[0] - p1[0])) +
                                   ((p[1] - p1[1]) * (p[1] - p1[1])) +
                                   ((p[2] - p1[2]) * (p[2] - p1[2]))));
            else
                return ((float)Math.Sqrt(((p[0] - p1[0]) * (p[0] - p1[0])) +
                                    ((p[1] - p1[1]) * (p[1] - p1[1]))));

        }

        public bool FloatEqu(float v, float x)
        {
            return (((v - 0.0001f) < x) && (x < (v + 0.0001f))) ? true : false;
        }

        public bool IntersectOf2DLine(float[] pt11, float[] pt12, float[] pt21, float[] pt22, float[] inteSect)
        {
            float fDis0 = FindDisBtPt(pt11, pt12, false);
            float fDis1 = FindDisBtPt(pt21, pt22, false);

            if (fDis0 < 0.001f || fDis1 < 0.001f)
            {
                return false;
            }

            float[] m = new float[2];
            float[] c = new float[2];
            //float m[2],c[2];
            float diffx, diffy;
            float fInfinity = 1000000000.0f;

            diffx = pt11[0] - pt12[0];
            diffy = pt11[1] - pt12[1];

            if (FloatEqu(diffx, 0.0f))
                m[0] = fInfinity;
            else
                m[0] = diffy / diffx;

            c[0] = pt11[1] - m[0] * pt11[0];


            diffx = pt21[0] - pt22[0];
            diffy = pt21[1] - pt22[1];

            if (FloatEqu(diffx, 0.0f))
                m[1] = fInfinity;
            else
                m[1] = diffy / diffx;

            c[1] = pt22[1] - m[1] * pt22[0];


            if ((m[0] - m[1]) == 0.0f)
            {
                return false;
            }
            else if (m[0] > 10000000.0f)
            {
                inteSect[0] = pt11[0];
                inteSect[1] = m[1] * inteSect[0] + c[1];
                return true;
            }
            else if (m[1] > 10000000.0f)
            {
                inteSect[0] = pt21[0];
                inteSect[1] = m[0] * inteSect[0] + c[0];
                return true;

            }

            inteSect[0] = (c[1] - c[0]) / (m[0] - m[1]);
            inteSect[1] = m[0] * inteSect[0] + c[0];

            return true;
        }

        public void RotatePoint(float[] p, float[] angle, int rotatetype = 0)
        {
            float[] fSin = new float[3];
            float[] fCos = new float[3];

            fSin[0] = fSin[1] = fSin[2] = 0.0f;
            fCos[0] = fCos[1] = fCos[2] = 0.0f;
            //float fSin[3]={0.0f},fCos[3]={0.0f};
            int i = 0;

            for (i = 0; i < 3; i++)
            {
                if (angle[i] != 0.0f)
                {
                    fCos[i] = (float)Math.Cos(angle[i] / 180 * Math.PI);
                    fSin[i] = (float)Math.Sin(angle[i] / 180 * Math.PI);
                }
            }

            switch (rotatetype)
            {
                case 0:    //Simplae Rotate

                    if (angle[0] != 0.0f)
                    {
                        i = 0;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];

                        p[1] = pt[1] * fCos[i] - pt[2] * fSin[i];
                        p[2] = pt[1] * fSin[i] + pt[2] * fCos[i];
                    }

                    if (angle[1] != 0.0f)
                    {
                        i = 1;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[2] = pt[2] * fCos[i] - pt[0] * fSin[i];
                        p[0] = pt[2] * fSin[i] + pt[0] * fCos[i];
                    }


                    if (angle[2] != 0.0f)
                    {
                        i = 2;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[0] = pt[0] * fCos[i] - pt[1] * fSin[i];
                        p[1] = pt[0] * fSin[i] + pt[1] * fCos[i];
                    }

                    break;
                case 1:     //RotatePointXYLineToAnyLine

                    if (angle[2] != 0.0f)
                    {
                        i = 2;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[0] = pt[0] * fCos[i] - pt[1] * fSin[i];
                        p[1] = pt[0] * fSin[i] + pt[1] * fCos[i];
                    }

                    if (angle[1] != 0.0f)
                    {
                        i = 1;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[2] = pt[2] * fCos[i] - pt[0] * fSin[i];
                        p[0] = pt[2] * fSin[i] + pt[0] * fCos[i];
                    }

                    if (angle[0] != 0.0f)
                    {
                        i = 0;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[1] = pt[1] * fCos[i] - pt[2] * fSin[i];
                        p[2] = pt[1] * fSin[i] + pt[2] * fCos[i];
                    }

                    break;
                case 2:			//RotatePointXYPlaneToAnyPlane

                    if (angle[0] != 0.0f)
                    {
                        i = 0;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[1] = pt[1] * fCos[i] - pt[2] * fSin[i];
                        p[2] = pt[1] * fSin[i] + pt[2] * fCos[i];
                    }

                    if (angle[2] != 0.0f)
                    {
                        i = 2;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[0] = pt[0] * fCos[i] - pt[1] * fSin[i];
                        p[1] = pt[0] * fSin[i] + pt[1] * fCos[i];
                    }
                    if (angle[1] != 0.0f)
                    {
                        i = 1;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[2] = pt[2] * fCos[i] - pt[0] * fSin[i];
                        p[0] = pt[2] * fSin[i] + pt[0] * fCos[i];
                    }
                    break;
                case 3:     //Inverse Rotate
                    {


                        if (angle[2] != 0.0f)
                        {
                            i = 2;
                            float[] pt = new float[3];
                            pt[0] = p[0];
                            pt[1] = p[1];
                            pt[2] = p[2];
                            p[0] = pt[0] * fCos[i] - pt[1] * fSin[i];
                            p[1] = pt[0] * fSin[i] + pt[1] * fCos[i];
                        }


                        if (angle[1] != 0.0f)
                        {
                            i = 1;
                            float[] pt = new float[3];
                            pt[0] = p[0];
                            pt[1] = p[1];
                            pt[2] = p[2];
                            p[2] = pt[2] * fCos[i] - pt[0] * fSin[i];
                            p[0] = pt[2] * fSin[i] + pt[0] * fCos[i];
                        }

                        if (angle[0] != 0.0f)
                        {
                            i = 0;
                            float[] pt = new float[3];
                            pt[0] = p[0];
                            pt[1] = p[1];
                            pt[2] = p[2];
                            p[1] = pt[1] * fCos[i] - pt[2] * fSin[i];
                            p[2] = pt[1] * fSin[i] + pt[2] * fCos[i];
                        }
                    }

                    break;


                case 4:
                    {

                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];

                        if (angle[2] != 0.0f)
                        {

                            p[0] = pt[0] * (float)Math.Cos(angle[2] / 180 * Math.PI) - pt[1] * (float)Math.Sin(angle[2] * Math.PI / 180);
                            p[1] = pt[0] * (float)Math.Sin(angle[2] / 180 * Math.PI) + pt[1] * (float)Math.Cos(angle[2] * Math.PI / 180);
                            p[2] = p[2];

                        }


                        if (angle[1] != 0.0f)
                        {
                            //float pt[3]={p[0],p[1],p[2]};

                            p[2] = pt[2] * (float)Math.Cos(angle[1] / 180 * Math.PI) - pt[0] * (float)Math.Sin(angle[1] * Math.PI / 180);
                            p[0] = pt[2] * (float)Math.Sin(angle[1] / 180 * Math.PI) + pt[0] * (float)Math.Cos(angle[1] * Math.PI / 180);
                            p[1] = p[1];

                        }

                        if (angle[0] != 0.0f)
                        {
                            //float pt[3]={p[0],p[1],p[2]};

                            p[1] = pt[1] * (float)Math.Cos(angle[0] / 180 * Math.PI) - pt[2] * (float)Math.Sin(angle[0] * Math.PI / 180);
                            p[2] = pt[1] * (float)Math.Sin(angle[0] / 180 * Math.PI) + pt[2] * (float)Math.Cos(angle[0] * Math.PI / 180);
                            p[0] = p[0];
                        }
                    }

                    break;
                case 5:
                    {
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];

                        if (angle[0] != 0.0f)
                        {

                            p[1] = pt[1] * (float)Math.Cos(angle[0] / 180 * Math.PI) - pt[2] * (float)Math.Sin(angle[0] * Math.PI / 180);
                            p[2] = pt[1] * (float)Math.Sin(angle[0] / 180 * Math.PI) + pt[2] * (float)Math.Cos(angle[0] * Math.PI / 180);
                            p[0] = p[0];
                        }

                        if (angle[1] != 0.0f)
                        {
                            //  float pt[3]={p[0],p[1],p[2]};

                            p[2] = pt[2] * (float)Math.Cos(angle[1] / 180 * Math.PI) - pt[0] * (float)Math.Sin(angle[1] * Math.PI / 180);
                            p[0] = pt[2] * (float)Math.Sin(angle[1] / 180 * Math.PI) + pt[0] * (float)Math.Cos(angle[1] * Math.PI / 180);
                            p[1] = p[1];

                        }


                        if (angle[2] != 0.0f)
                        {
                            //  float pt[3]={p[0],p[1],p[2]};

                            p[0] = pt[0] * (float)Math.Cos(angle[2] / 180 * Math.PI) - pt[1] * (float)Math.Sin(angle[2] * Math.PI / 180);
                            p[1] = pt[0] * (float)Math.Sin(angle[2] / 180 * Math.PI) + pt[1] * (float)Math.Cos(angle[2] * Math.PI / 180);
                            p[2] = p[2];

                        }
                    }
                    break;

                case 6: //Any Plane To XY PLANE

                    if (angle[1] != 0.0f)
                    {
                        i = 1;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[2] = pt[2] * fCos[i] - pt[0] * fSin[i];
                        p[0] = pt[2] * fSin[i] + pt[0] * fCos[i];
                    }

                    if (angle[2] != 0.0f)
                    {
                        i = 2;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[0] = pt[0] * fCos[i] - pt[1] * fSin[i];
                        p[1] = pt[0] * fSin[i] + pt[1] * fCos[i];
                    }


                    if (angle[0] != 0.0f)
                    {
                        i = 0;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[1] = pt[1] * fCos[i] - pt[2] * fSin[i];
                        p[2] = pt[1] * fSin[i] + pt[2] * fCos[i];
                    }
                    break;
                case 7: //2,0,1

                    if (angle[2] != 0.0f)
                    {
                        i = 2;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[0] = pt[0] * fCos[i] - pt[1] * fSin[i];
                        p[1] = pt[0] * fSin[i] + pt[1] * fCos[i];
                    }

                    if (angle[0] != 0.0f)
                    {
                        i = 0;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[1] = pt[1] * fCos[i] - pt[2] * fSin[i];
                        p[2] = pt[1] * fSin[i] + pt[2] * fCos[i];
                    }


                    if (angle[1] != 0.0f)
                    {
                        i = 1;
                        float[] pt = new float[3];
                        pt[0] = p[0];
                        pt[1] = p[1];
                        pt[2] = p[2];
                        p[2] = pt[2] * fCos[i] - pt[0] * fSin[i];
                        p[0] = pt[2] * fSin[i] + pt[0] * fCos[i];
                    }

                    break;
            }
        }

        public bool PointCloud(List<st2DInfo> cArrInput, List<POINT3D> cArrOutput, float fAngleOffcet)
        {
            cArrOutput.RemoveRange(0, cArrOutput.Count);
            //float f1 = 0.0f, f2 = 0.0f, f3 = 0.0f;
            //int d1 = 0;
            float[] rang = new float[3];
            rang[0] = rang[1] = rang[2] = 0.0f;

            float[,] pt = new float[2, 3];
            float[,] final = new float[2, 3];
            float[] cal = new float[3];
            float startAng;

            float[] ang = new float[20000];
            float[] height = new float[2];
            float[] rad = new float[20000];
            float[] fShiftPoint = new float[3] { 0.0f, 0.0f, 0.0f };

            float fOutScanAng = /*0.89999998f*/fAngleOffcet;
            float X = 0, Y = 0/*, Z = 0*/;
            float fSensorDis = 0.0f;
            float fVideoOffset = 0.0f;

            float[] a1 = new float[3];
            float[] a2 = new float[3];

            fVideoOffset += 180.0f;

            int fOutNoOfCol;
            fOutNoOfCol = (int)((360.0f / fOutScanAng) + 1);

            if (fOutNoOfCol < cArrInput.Count)
            {
                MessageBox.Show("Error: Rotary Angle BIG");
                return false;
            }

            POINT3D[] sLayerPt = new POINT3D[fOutNoOfCol];
            POINT3D[] Line1 = new POINT3D[fOutNoOfCol];
            POINT3D[] Line2 = new POINT3D[fOutNoOfCol];

            //POINT2D pt2D;
            POINT3D pt3D;

            int iSize = cArrInput.Count;

            for (int i = 0; i < cArrInput.Count; i++)
            {
                //f3 = 384.0f - f3;

                ang[i] = cArrInput[i].fAngle;
                rad[i] = 684.0f - cArrInput[i].fRad;
                height[0] = cArrInput[i].fHeight;
                rang[2] = cArrInput[i].fAngle;

                pt[0, 0] = rad[i];
                pt[0, 1] = 5.0f;
                pt[0, 2] = 0.0f;

                pt[1, 0] = rad[i];
                pt[1, 1] = -5.0f;
                pt[1, 2] = 0.0f;

                a1[0] = pt[0, 0];
                a1[1] = pt[0, 1];
                a1[2] = pt[0, 2];

                a2[0] = pt[1, 0];
                a2[1] = pt[1, 1];
                a2[2] = pt[1, 2];

                RotatePoint(a1, rang);
                RotatePoint(a2, rang);

                pt[0, 0] = a1[0];
                pt[0, 1] = a1[1];
                pt[0, 2] = a1[2];

                pt[1, 0] = a2[0];
                pt[1, 1] = a2[1];
                pt[1, 2] = a2[2];

                Line1[i].x = pt[0, 0];
                Line1[i].y = pt[0, 1];

                Line2[i].x = pt[1, 0];
                Line2[i].y = pt[1, 1];
            }

            if (true)
            {
                string lines;
                System.IO.StreamWriter file = new System.IO.StreamWriter("E://cArrLine1.txt");

                for (int i = 0; i < iSize; i++)
                {
                    lines = String.Format("{0},{2},{2}\n", i, Line1[i].x, Line1[i].y);
                    file.WriteLine(lines);
                }
                file.Close();
            }
            if (true)
            {
                string lines;
                System.IO.StreamWriter file = new System.IO.StreamWriter("E://cArrLine2.txt");

                for (int i = 0; i < iSize; i++)
                {
                    lines = String.Format("{0},{2},{2}\n", i, Line2[i].x, Line2[i].y);
                    file.WriteLine(lines);
                }
                file.Close();
            }

            pt[0, 0] = (Line1[iSize / 4].x + Line1[iSize / 4 + iSize / 2].x) / 2.0f;
            pt[0, 1] = (Line1[iSize / 4].y + Line1[iSize / 4 + iSize / 2].y) / 2.0f;

            pt[1, 0] = (Line1[0].x + Line1[iSize / 2].x) / 2.0f;
            pt[1, 1] = (Line1[0].y + Line1[iSize / 2].y) / 2.0f;

            fShiftPoint[0] = (pt[1, 0]);
            fShiftPoint[1] = (pt[0, 1]);

            if (fShiftPoint[0] != 0.0f || fShiftPoint[1] != 0.0f)
            {
                for (int i = 0; i < iSize; i++)
                {
                    Line1[i].x -= fShiftPoint[0];
                    Line1[i].y -= fShiftPoint[1];
                    Line2[i].x -= fShiftPoint[0];
                    Line2[i].y -= fShiftPoint[1];
                }
            }

            int lCol;
            int lCol1;
            // iAngIndex=0;

            float[] b1 = new float[3];
            float[] b2 = new float[3];


            for (ang[1] = 0.0f; ang[1] < 180.0f - fOutScanAng / 2; ang[1] += fOutScanAng)
            {
                startAng = ang[1];

                pt[0, 0] = 0.0f;
                pt[0, 1] = 0.0f;

                final[0, 1] = 1000.0f;
                final[1, 1] = -1000.0f;
                final[0, 2] = 1000.0f;
                final[1, 2] = 1000.0f;

                pt[1, 0] = (float)(10.0f * Math.Cos(startAng * Math.PI / 180));
                pt[1, 1] = (float)(10.0f * Math.Sin(startAng * Math.PI / 180));

                float[] fa1 = new float[3];
                float[] fa2 = new float[3];

                for (int j = 0; j < iSize; j++)
                {
                    fa1[0] = Line1[j].x;
                    fa1[1] = Line1[j].y;
                    fa1[2] = Line1[j].z;

                    fa2[0] = Line2[j].x;
                    fa2[1] = Line2[j].y;
                    fa2[2] = Line2[j].z;

                    b1[0] = pt[0, 0];
                    b1[1] = pt[0, 1];
                    b1[2] = pt[0, 2];

                    b2[0] = pt[1, 0];
                    b2[1] = pt[1, 1];
                    b2[2] = pt[1, 2];

                    if (IntersectOf2DLine(fa1, fa2,
                    b1, b2, cal) == false)
                    {
                        continue;
                    }

                    //cal[2]= Math.Sqrt(cal[0]*cal[0]+cal[1]*cal[1]);
                    cal[2] = (float)Math.Sqrt((cal[0] * cal[0] + cal[1] * cal[1]));
                    final[1, 0] = TanInverse(cal[0], cal[1]);

                    if (final[1, 0] > 359.9f)
                        final[1, 0] = 0.0f;
                    else if (final[1, 0] > 179.9f)
                        final[1, 0] = 180.0f;

                    if (final[1, 0] < 180.0f)
                    {
                        if (cal[2] < final[0, 2])
                        {
                            final[0, 2] = cal[2];
                            lCol = j;
                        }
                    }
                    else
                    {
                        if (cal[2] < final[1, 2])
                        {
                            final[1, 2] = cal[2];
                            lCol1 = j;
                        }
                    }
                }

                if (FloatEqu(startAng, ang[1]))
                {
                    lCol = (int)((ang[1] + fOutScanAng / 2) / fOutScanAng);

                    sLayerPt[lCol].x = ang[1];
                    sLayerPt[lCol].y = startAng;
                    sLayerPt[lCol].z = final[0, 2];

                    lCol1 = (int)((ang[1] + 180 + fOutScanAng / 2) / fOutScanAng);
                    sLayerPt[lCol1].x = ang[1] + 180.0f;
                    sLayerPt[lCol1].y = startAng + 180.0f;
                    sLayerPt[lCol1].z = final[1, 2];
                }
                else
                {
                    MessageBox.Show("Error::bBigScan");
                }
            }

            if (fShiftPoint[0] != 0.0f || fShiftPoint[1] != 0.0f)
            {
                float x, y, r, ang1;
                //FILE *fp;
                //fp = NULL;

                //fopen_s(&fp,"D://vyara.txt","w");
                for (int i = 0; i < fOutNoOfCol; i++)
                {
                    x = (float)(sLayerPt[i].z * Math.Cos(sLayerPt[i].x * Math.PI / 180));
                    y = (float)(sLayerPt[i].z * Math.Sin(sLayerPt[i].x * Math.PI / 180));
                    x += fShiftPoint[0];
                    y += fShiftPoint[1];
                    r = (float)Math.Sqrt(x * x + y * y);
                    r = -r;
                    ang1 = TanInverse(x, y);

                    /*if(r>25.0f)
                        r=0.0f;*/
                    {
                        X = (float)(Math.Abs(fSensorDis - r) * Math.Cos((ang1 + fVideoOffset) * Math.PI / 180.0f));
                        Y = (float)(Math.Abs(fSensorDis - r) * Math.Sin((ang1 + fVideoOffset) * Math.PI / 180.0f));

                        pt3D.x = X;
                        pt3D.y = Y;
                        pt3D.z = height[0];

                        //fprintf(fp,"%d,%f,%f\n",i,X,Y);

                        //ptf.x = X;
                        //ptf.y = Y;
                        cArrOutput.Add(pt3D);
                    }
                }
                //fclose(fp);
            }
            else
            {
                //AfxMessageBox("Loop not come here");
                for (int j = 0; j < 401; j++)
                {
                    {
                        X = (float)(Math.Abs(fSensorDis - sLayerPt[j].z) * Math.Cos((j * fOutScanAng + fVideoOffset) * Math.PI / 180.0f));
                        Y = (float)(Math.Abs(fSensorDis - sLayerPt[j].z) * Math.Sin((j * fOutScanAng + fVideoOffset) * Math.PI / 180.0f));

                        pt3D.x = X;
                        pt3D.y = Y;
                        pt3D.z = height[0];

                        cArrOutput.Add(pt3D);
                    }
                }
            }

            return true;
        }

        #endregion

        #region Events

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            MyFunction();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Done");
        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
            //Thread background = new Thread(MyFunction);
            //background.IsBackground = true;
            //background.Start();

            //MyFunction();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            List<List<string>> lst2DData = new List<List<string>>();

            List<string> lstAllData = GetFileData();

            int iCount = 0;
            int iNumber = 201;
            while (lstAllData.Count > (iCount * iNumber))
            {
                lst2DData.Add(lstAllData.Skip(iCount * iNumber).Take(iNumber).ToList());
                iCount = iCount + 1;
            }

            List<POINT3D> cArrJigar = new List<POINT3D>();
            string[] str = new string[3];
            st2DInfo st2D;
            float fAngstep = 1.8f;

            List<st2DInfo> cArrInput = new List<st2DInfo>();
            List<POINT3D> cArrOutput = new List<POINT3D>();

            foreach (List<string> list in lst2DData)
            {
                List<st2DInfo> cArrTemp = new List<st2DInfo>();

                foreach (string lines in list)
                {
                    str = lines.Trim().Split(' ');

                    st2D.fAngle = float.Parse(str[0]);
                    st2D.fHeight = float.Parse(str[1]);
                    st2D.fRad = float.Parse(str[2]);
                    cArrTemp.Add(st2D);
                }

                cArrTemp.RemoveAt(cArrTemp.Count - 1);

                if (PointCloud(cArrTemp, cArrOutput, fAngstep))
                {
                    POINT3D ptTemp;

                    POINT2D ptCentroid;
                    ptCentroid.x = 0.0f;
                    ptCentroid.y = 0.0f;
                    GetClosedPolygonCentroid(cArrOutput, cArrOutput.Count, ref ptCentroid);

                    foreach (var item in cArrOutput)
                    {
                        ptTemp.x = item.x - ptCentroid.x/*cArrOutput[400].x*/;
                        ptTemp.y = item.y - ptCentroid.y/*cArrOutput[400].y*/;
                        ptTemp.z = item.z;

                        cArrJigar.Add(ptTemp);
                    }
                    cArrOutput.RemoveRange(0, cArrOutput.Count);
                }
                else
                {
                    break;
                }
                if (cArrOutput.Count > 0)
                {
                    cArrOutput.RemoveAt(cArrOutput.Count - 1);
                }
            }

            string lines_out;
            System.IO.StreamWriter file = new System.IO.StreamWriter("E:/out.txt");

            for (int i = 0; i < cArrJigar.Count; i++)
            {
                lines_out = String.Format("{0},{1},{2}\n", cArrJigar[i].x, cArrJigar[i].y, cArrJigar[i].z);
                file.WriteLine(lines_out);
            }
            file.Close();

            MessageBox.Show("Completed");
        }

        #endregion

    }
}
