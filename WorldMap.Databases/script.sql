USE [CountryPractice]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllCities]    Script Date: 13-03-2019 09:42:11 ******/
DROP PROCEDURE IF EXISTS [dbo].[SelectAllCities]
GO
/****** Object:  StoredProcedure [dbo].[findTextFromAllObjects]    Script Date: 13-03-2019 09:42:11 ******/
DROP PROCEDURE IF EXISTS [dbo].[findTextFromAllObjects]
GO
/****** Object:  StoredProcedure [dbo].[findColumnNameFromAllTables]    Script Date: 13-03-2019 09:42:11 ******/
DROP PROCEDURE IF EXISTS [dbo].[findColumnNameFromAllTables]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoleMapping]') AND type in (N'U'))
ALTER TABLE [dbo].[UserRoleMapping] DROP CONSTRAINT IF EXISTS [FK_dbo.UserRoleMapping_dbo.UserData_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoleMapping]') AND type in (N'U'))
ALTER TABLE [dbo].[UserRoleMapping] DROP CONSTRAINT IF EXISTS [FK_dbo.UserRoleMapping_dbo.RoleData_RoleId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateData]') AND type in (N'U'))
ALTER TABLE [dbo].[StateData] DROP CONSTRAINT IF EXISTS [FK_StateData_StateData]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateData]') AND type in (N'U'))
ALTER TABLE [dbo].[StateData] DROP CONSTRAINT IF EXISTS [FK_dbo.StateData_dbo.CountryData_CountryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OverseasTerritoriesData]') AND type in (N'U'))
ALTER TABLE [dbo].[OverseasTerritoriesData] DROP CONSTRAINT IF EXISTS [FK_dbo.OverseasTerritoriesData_dbo.CountryData_CountryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountryData]') AND type in (N'U'))
ALTER TABLE [dbo].[CountryData] DROP CONSTRAINT IF EXISTS [FK_dbo.CountryData_dbo.ContinentData_ContinentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountryData]') AND type in (N'U'))
ALTER TABLE [dbo].[CountryData] DROP CONSTRAINT IF EXISTS [FK_CountryData_ContinentData]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CityData]') AND type in (N'U'))
ALTER TABLE [dbo].[CityData] DROP CONSTRAINT IF EXISTS [FK_dbo.CityData_dbo.StateData_StateId]
GO
/****** Object:  Table [dbo].[UserRoleMapping]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[UserRoleMapping]
GO
/****** Object:  Table [dbo].[UserData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[UserData]
GO
/****** Object:  Table [dbo].[StateData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[StateData]
GO
/****** Object:  Table [dbo].[RoleData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[RoleData]
GO
/****** Object:  Table [dbo].[OverseasTerritoriesData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[OverseasTerritoriesData]
GO
/****** Object:  Table [dbo].[CountryData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[CountryData]
GO
/****** Object:  Table [dbo].[ContinentData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[ContinentData]
GO
/****** Object:  Table [dbo].[CityData]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[CityData]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 13-03-2019 09:42:11 ******/
DROP TABLE IF EXISTS [dbo].[__MigrationHistory]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnSplitString]    Script Date: 13-03-2019 09:42:11 ******/
DROP FUNCTION IF EXISTS [dbo].[ufnSplitString]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnsRemoveSpecialChars]    Script Date: 13-03-2019 09:42:11 ******/
DROP FUNCTION IF EXISTS [dbo].[ufnsRemoveSpecialChars]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnSplitStrToTable]    Script Date: 13-03-2019 09:42:11 ******/
DROP FUNCTION IF EXISTS [dbo].[ufnSplitStrToTable]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnsGetDateWithOrdinal]    Script Date: 13-03-2019 09:42:11 ******/
DROP FUNCTION IF EXISTS [dbo].[ufnsGetDateWithOrdinal]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnsDateDiffinYrMonDay]    Script Date: 13-03-2019 09:42:11 ******/
DROP FUNCTION IF EXISTS [dbo].[ufnsDateDiffinYrMonDay]
GO
/****** Object:  UserDefinedFunction [dbo].[ufnsDateDiffinYrMonDay]    Script Date: 13-03-2019 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mitesh
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufnsDateDiffinYrMonDay] (@datefrom DATETIME, @dateto DATETIME)
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @Years INT, @Months INT, @Days INT
    SET @Years = DATEDIFF(YEAR, @datefrom, @dateto)
    IF DATEADD(YY, @Years, @datefrom) > @dateto
    BEGIN
        SET @Years = @Years - 1
    END

    SET @datefrom = DATEADD(YY, @Years, @datefrom)
    SET @Months = DATEDIFF(MM, @datefrom, @dateto)

    IF DATEADD(MM, @Months, @datefrom) > @dateto
    BEGIN
        SET @Months = @Months - 1
    END

    SET @datefrom = DATEADD(MM, @Months, @datefrom)
    SET @Days = DATEDIFF(DD, @datefrom, @dateto)

	IF(@datefrom = @dateto)
	BEGIN
	SET @Days = 1
	END

    RETURN CAST(@Years AS VARCHAR) + ' Year(s) '
            + CAST(@Months AS VARCHAR) + ' Month(s) '
            + CAST(@Days AS VARCHAR) + ' Day(s)'
END
GO
/****** Object:  UserDefinedFunction [dbo].[ufnsGetDateWithOrdinal]    Script Date: 13-03-2019 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*************************************************************
** File: [ufnsGetDateWithOrdinal]
** Author: Mitesh Patel
** Description: Get date with ordinal like 14th Mar 2016
** Date: 03/12/2019
**************************************************************/

CREATE FUNCTION [dbo].[ufnsGetDateWithOrdinal](@date DATE)
RETURNS NVARCHAR(100) 
AS
BEGIN
DECLARE @dt NVARCHAR(100);

WITH CTE
AS (SELECT
		1 n UNION ALL SELECT
		n + 1
	FROM CTE
	WHERE n <= DAY(@date))

SELECT
	@dt =
	CAST(n AS VARCHAR(10))
	+
	CASE
		WHEN n % 100 IN (11, 12, 13) THEN 'th'
		WHEN n % 10 = 1 THEN 'st'
		WHEN n % 10 = 2 THEN 'nd'
		WHEN n % 10 = 3 THEN 'rd'
		ELSE 'th'
	END
	+ FORMAT(@date, ' MMM yyyy')
FROM CTE
WHERE n = DAY(@date)
OPTION (MAXRECURSION 100)

RETURN @dt;
END



GO
/****** Object:  UserDefinedFunction [dbo].[ufnSplitStrToTable]    Script Date: 13-03-2019 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mitesh Patel
-- Create date: 03/12/2019
-- Description:	Will Return Comma Separated String To Table
-- =============================================

CREATE FUNCTION [dbo].[ufnSplitStrToTable]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN

	IF(@Input IS NOT NULL AND @Input <> '')
	BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
 
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 END
 ELSE
 BEGIN
 INSERT INTO @Output VALUES(NULL)
 END
      RETURN
END




GO
/****** Object:  UserDefinedFunction [dbo].[ufnsRemoveSpecialChars]    Script Date: 13-03-2019 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnsRemoveSpecialChars] ( @InputString VARCHAR(8000) )
RETURNS VARCHAR(8000)  
BEGIN
    IF @InputString IS NULL
        RETURN NULL
    DECLARE @OutputString VARCHAR(8000)
    SET @OutputString = ''
    DECLARE @l INT
    SET @l = LEN(@InputString)
    DECLARE @p INT
    SET @p = 1
    WHILE @p <= @l
        BEGIN
            DECLARE @c INT
            SET @c = ASCII(SUBSTRING(@InputString, @p, 1))
            IF @c BETWEEN 48 AND 57
                OR @c BETWEEN 65 AND 90
                OR @c BETWEEN 97 AND 122
                  --OR @c = 32
                SET @OutputString = @OutputString + CHAR(@c)
            SET @p = @p + 1
        END
    IF LEN(@OutputString) = 0
        RETURN NULL
    RETURN REPLACE(@OutputString,' ', '')
END





GO
/****** Object:  UserDefinedFunction [dbo].[ufnSplitString]    Script Date: 13-03-2019 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*************************************************************   
** File:     [ufnSplitString]  
** Description: To split string by delimiter using xml
**************************************************************   
** Change History   
**************************************************************   
** PR   Date        Author         Change Description    
** --   --------    -------     -----------------------------  
** 1.   07/06/2016  D Sahoo		CREATED

**************************************************************/  
CREATE FUNCTION [dbo].[ufnSplitString]
(
   @var       NVARCHAR(MAX),
   @delimiter  NVARCHAR(10)
)
RETURNS TABLE
WITH SCHEMABINDING
AS
   RETURN
   (
      SELECT Item = RTRIM(LTRIM(b.htd.value('(./text())[1]', 'NVARCHAR(4000)')))
      FROM
      (
        SELECT string = CAST('<htd>'
          + REPLACE(@var, @delimiter, '</htd><htd>')
          + '</htd>' AS xml).query('.')
      ) AS a CROSS APPLY string.nodes('htd') AS b(htd)
   );



GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 13-03-2019 09:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CityData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityData](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CityData] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContinentData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContinentData](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[ContinentName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ContinentData] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryData](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[CountryCapital] [nvarchar](50) NOT NULL,
	[CountryArea] [float] NOT NULL,
	[ContinentId] [int] NOT NULL,
	[IsIsland] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CountryData] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OverseasTerritoriesData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OverseasTerritoriesData](
	[OverseasTerritoriesId] [int] IDENTITY(1,1) NOT NULL,
	[OverseasTerritoriesName] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OverseasTerritoriesData] PRIMARY KEY CLUSTERED 
(
	[OverseasTerritoriesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleData](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.RoleData] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StateData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateData](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
	[StateCapital] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.StateData] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserData]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserData](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.UserData] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleMapping]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleMapping](
	[UserRoleMappingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[UserRoleMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201812141459486_InitialCreate', N'WorldMap.DAL.WorldMapDBContext', 0x1F8B0800000000000400DD5DCD6EDC3812BE0FB0EF20E8B8482CDBC1003346F7044E3B1E34268E83B433BB378396D86D6125AA47621B3606FB647B98479A575852BF94488AA47EDB412E6E89552C567D55228B2CE6EFFFFDB578FF1C06D6138C133F424BFBECE4D4B6207223CF47BBA57DC0DBB73FD9EF7FF9C70F8B8F5EF86CFD5EB47B47DB114A942CED478CF7178E93B88F3004C949E8BB7194445B7CE246A103BCC8393F3DFDD9393B73206161135E96B5F87A40D80F61FA83FC5C45C8857B7C00C14DE4C120C99F93379B94ABF5198430D903172EED7F4571E0DD80FDC9D5E527DBBA0C7C4064D8C0606B5B00A108034C24BCF896C00D8E23B4DBECC90310DCBDEC2169B705410273C92FAAE6BA83383DA783702AC282957B4870141A323C7B976BC5699277D2AD5D6A8DE8ED23D12F7EA1A34E75B7B457E4E715C0C0B69A9D5DAC82983664549B5AE1A4207963D55FBC297140E042FFBDB15687001F62B844F08063405A7C393C04BEFB1B7CB98BFE03D1121D8280958F4848DED51E90475FE2680F63FCF2156E19A9D79E6D39755AA7495C9236E8B271AD117E776E5B9F8910E02180250C181D6C7014C35F218231C0D0FB02308631B1E2DA83A922390904FDD1BF8A1E09F68803D9D60D78FE04D10E3F2EED1F89C75CFBCFD02B1EE4427C433E71374283E3031408D9DEF186C80FD5236D67B24E2E5DEC3F95D27F88A20002A4E0B3702A90B5432F224F1051A429FE58BA394158C8D109892CF164702C3A9D0593DDE044F87C064FFE2E554083A31B91EF459CC7AFAF3048DB248FFE3E8BFC75A4DCD75A5FC751F8350A9A30641BDD6FA243EC52712355CB3B10EF20EEEC078C5C065E5052CDEA03A914DD3CA0249D0EFF6997B3A03FEF7B05F63E06C15CDD5FC610147D5F4504035D3869472E553C582701409E713C183DAE4474E20B417207E3D82790F361D21263AA3020A563A38DB2B920EEA8694411A86D88099D20680D8A69291E46D9A055F0AA55AF60792B53B176E094709831880A24EA1250256CA60AAE82EEE70CB466D1491B7F9BCA1BB41157D2CC88B17241608A2ACD95C470384A3B9C6FD134F3077A9E355BEB24BBCC10083E1425B4EFAB66D557827FCB7D22044D7A7D1F285743F72C4866F44E2A4217E72CE8A6F24DDADF34AE2985E3218131158398699FF62D406561D17BAE71854D591B0EA1D286BD70FAAD2999365C1B9433A2B6214917000B584C8565DA75DF68ABE77F9D016218C80A929921D11507531BFF1504B2C2A26D814CD6860B64D2862681EC324922D74FE5E4D357D205705D251F916775580D67866A2C4F89C90894FD3D012F9176699FD94D90DEA22B18400C2D3A31A25B302B90B8C0E32D4546ECF511B4502323A874B55A17FA9F9C2CC4A3604CA10C82154104F1511F61DEFD7CE4FA7B10986BB3C1CA2CB7477555F6DD7C7305F710512F34D75C6FA1CABE1B86556973E130B06E47BB60C22BC34CDBECB78208B3A09C04C92D136ED6C3CAD9FC284895AB46070392B5AC112CE56AE829C104181467E77442972055772C5195CF0FEA38C9089193D3D13CB192D3C76B888EF20D37390494BB6F2C426B3BC6136154B5E9A7E742832155A12F3D984877AE0DF1AAD0CD00C24C805A69BA40860975EEA0824495909A04AECA6C05231A97831805B12A65E960449C1F33C2AA4A31FDC49800A5D2B5A00C0AEA85611D0A13A254B9149D1CA52A65E9C0439CFC3042A94A31FDC4181CA5598E8046704201E35C8022FB74F581BE81CF5890C32242E669AC24CFA434B142396F20E6CE295679096EADE22878D4A70F3CA3FA7B2537E65B2FE0C5BC557092660938AED2968A1E98F933C79379A7E0527DCA3826D52B050FCE9B39565C0B0D8E12A9AA570D1E0C9C8506959FE460280D0E80343DB15B06AC1C79037C9CA377CB5B31EC7571E6D415A9A164D18621AF5355964537CFC20C490A73DDEC08AB7D59C431D787E4A44D3BCC248B7E83657F4F28F18B751D4D77528FF404A748455AAB4FC3F5674D552D1F08C355A39E053AA84CBEF9C96B4C6FE563B6F6610626FB2A98AD581886AA6F83B9B6E43B2CBCB6F466E06673F0C6E094DA52CE9C07D156B1FB53CEECCA770B272BBDC91F2C1C498DCE22EF94A9D9C99F589BAC6067F576635ECF12663C1C371194B594D2963D914F17D8C1C65BEA701EBCF6E324F5CE074077ED565EC835E3E7B1929948D15F63AACA5BB1989F1404F4EFFA9C99962F9DC838544ABC26E30AE9B221DD07157D9A38528B564D8100C4929A9855141C42D4565FA3E2926DA836F9644FF53995B975969134E12EE7539D846219554F794E0BA7A15D6E01C559905BF2D611A18797DA57A53B68DAD8E820A79D5E6A78367D57B37D5B5E4F839F004DF557DF2514DAE62CDA409032D182410BB5DC68E5BE43DD60D2ED08252F91F99917C6FCCA739D0296E53B63AE593D858065F6A203EC0772A3AAB8A20EF9E2E977E83CB2456B6747D264A8E154DA9C6446909CED672DA2554560D807EF84D246C6AE63142C6682D4A665A1AD0922290B0DD8B4D08E3D7B624EE1739C3ACDE884F1B7FE665C08BDFAF856AEA63B6351C641038A7252995E8BCD3256ABB20DB4762E3C0CABA747639DE662BBB391148C346CA5E42053B6E03436AB75E5796F156F11437338E8836A4628F4735419074DE39B39EA3096A94E5437F9CCE2A85C06ABD9A4ECBDCC643532568B3C7BA4BE7A864B27654D6C8BA8E8C9F7682A69F39260189ED006279B3F8255E093F1560D6E00F2B730C1D9E17BFBFCF4ECBC7187CDF1DC27E324891708B26F7A97CAAC91079F97F69FD67FE7BBF7C5A7AA57161098D6EFF9F5AB5ED01388DD4710733505FD6E724965976B95D25C58EB7FDFE7646FACDB98E0EBC23A250AEF5B4BF8E0E3A9EE7EE90993816F66190730A2CB588642CDA8A66BBBAEA4AFE186BB4E6424A37137880C6532F10521037367EFFFD8061150A142DF3D34621243DA332ED52F0E51837B5207D1BFA2A29FB34C716DC4284EA4B8296260C877C1694E6880D2412E90E88787A1AE7818C5E6DCAD0E83CE8FC60D9AD32068D218D5724D423F100E7393C128106C5E5ED00D250356F8F7D3F498D5F7A3E8BF5EE3ADEB4A19552F3F12604BA3E38C6A8C4F404B697F7F48F4AFBE1FCDF8E339DF6855E93317484AA792C750633E6161A4FE4EECF1D54476A9189FB542BCCADECD50103E590178CB19BBEFA6DE7BE6E86508E7571DA1CC003C774CEA59A77D0445D9C6181FA3FE7AE2626B535CB7F67BCC75D573165073CBB6D90AA6A7AA8C561F38F85E2AA1E72E799E17572D870A46AB6536C5D5ECB5CB7C6948D3A01DEA92B3F3004BDB7B8888DDB3D5ED5855CBC2BEC62A6C16773669E5B3488491CBA4455D0E5C452DEA62CC1A6B517FA31462CB3A120EEC28CBB43B15CF2A80FE8A8BAE3B14593763E66BACA9EE840243A51D7DBD74E7E26863351E6F1DB479C1B3243CBFEE02E76E95CCC3ABC1A072993FDF496693CC7F404826B489BFAB58D0FF8E1041B7368F2CDBACD1362AA6B30D898A268D1D911B888147947419637F0B5C4C5EBB3049D2E1FE0E820369F2317C80DE1ADD1EF0FE80C99061F810D4AE36A6D3E2B6FED3F2ECBACC8BDB7D7AC9F010432062FA6408F0167D38F88157CA7D2DD8B991B0A0F3ED7C9B89DA12D3EDA6DD4BC9E973843419E5EA2B97097730DC078459728B3680EEA19BCB4650F809EE80FB521CD39533511BA2AEF6C5950F763108939C47454F7E120C7BE1F32FFF07EC93A65A87730000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[CityData] ON 

INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (1, N'Surat', 1, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (2, N'Rajkot', 1, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (3, N'Vadodara', 1, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (4, N'Ahmedabad', 1, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (5, N'Margao', 3, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (6, N'Pune', 2, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (7, N'Sydney', 11, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (8, N'Melbourne', 15, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (9, N'Gold Coast', 11, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (10, N'Sunshine Coast', 12, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (11, N'Wollongong', 11, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (12, N'Geelong', 15, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (13, N'Invercargill', 21, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (14, N'Christchurch', 22, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (15, N'Johannesburg', 25, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (16, N'Emfuleni', 25, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (17, N'Durban', 26, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (18, N'Centurion', 25, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (19, N'East London', 23, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (20, N'Port Elizabeth', 23, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (21, N'Benoni', 25, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (22, N'Los Angeles', 42, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (23, N'San Diego', 42, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (24, N'San Francisco', 42, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (25, N'Chicago', 43, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (26, N'Cedar Rapids', 44, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (27, N'Columbus', 47, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (28, N'Cleveland', 47, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (29, N'Cincinnati', 47, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (30, N'Calgary', 56, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (31, N'Hamilton', 48, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (32, N'Montreal', 49, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (33, N'Vancouver', 53, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (34, N'Ottawa', 48, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (35, N'Middelburg', 62, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (36, N'Amsterdam', 63, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (37, N'Haarlem', 63, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (38, N'Maastricht', 64, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (39, N'Arlon', 66, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (40, N'Bruges', 67, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (41, N'Nuremberg', 68, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (42, N'Augsburg', 68, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (43, N'Stuttgart', 69, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (44, N'Karlsruhe', 69, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (45, N'Cologne', 70, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (46, N'Düsseldorf', 70, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (47, N'Dortmund', 70, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (48, N'Essen', 70, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (49, N'Kiel', 71, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (50, N'Lübeck', 71, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (51, N'Bonn', 70, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (52, N'Aalborg', 72, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (53, N'Hillerød', 73, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (54, N'Copenhagen', 73, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (55, N'Viborg', 74, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (56, N'Aarhus', 74, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (57, N'Lyon', 75, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (58, N'Saint-Étienne', 75, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (59, N'Nantes', 76, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (60, N'Angers', 76, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (61, N'Le Mans', 76, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (62, N'Bordeaux', 77, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (63, N'Bayonne', 77, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (64, N'Limoges', 77, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (65, N'The Hague', 78, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (66, N'Rotterdam', 78, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (67, N'Zaanstad', 63, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (68, N'''s-Hertogenbosch', 79, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (69, N'Eindhoven', 79, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (70, N'Tilburg', 79, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (71, N'Breda', 79, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (72, N'Nijmegen', 80, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (73, N'Apeldoorn', 80, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (74, N'Arnhem', 80, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (75, N'Utrecht', 81, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (76, N'Amersfoort', 81, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (77, N'Haarlemmermeer', 63, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (78, N'Zoetermeer', 78, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (79, N'Almere', 82, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (80, N'Lelystad', 82, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (81, N'Groningen', 83, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (82, N'Enschede', 84, 1)
INSERT [dbo].[CityData] ([CityId], [CityName], [StateId], [IsActive]) VALUES (83, N'Zwolle', 84, 1)
SET IDENTITY_INSERT [dbo].[CityData] OFF
SET IDENTITY_INSERT [dbo].[ContinentData] ON 

INSERT [dbo].[ContinentData] ([ContinentId], [ContinentName], [IsActive]) VALUES (1, N'Asia', 1)
INSERT [dbo].[ContinentData] ([ContinentId], [ContinentName], [IsActive]) VALUES (2, N'Europe', 1)
INSERT [dbo].[ContinentData] ([ContinentId], [ContinentName], [IsActive]) VALUES (3, N'Africa', 1)
INSERT [dbo].[ContinentData] ([ContinentId], [ContinentName], [IsActive]) VALUES (4, N'NorthAmerica', 1)
INSERT [dbo].[ContinentData] ([ContinentId], [ContinentName], [IsActive]) VALUES (5, N'SouthAmerica', 1)
INSERT [dbo].[ContinentData] ([ContinentId], [ContinentName], [IsActive]) VALUES (6, N'Pacific', 1)
SET IDENTITY_INSERT [dbo].[ContinentData] OFF
SET IDENTITY_INSERT [dbo].[CountryData] ON 

INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (1, N'India', N'Delhi', 3287263, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (2, N'USA', N'Washington DC', 9833520, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (3, N'Canada', N'Ottawa', 9984670, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (4, N'United Kingdom', N'London', 242495, 2, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (5, N'Ireland', N'Dublin', 70273, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (6, N'Germany', N'Berlin', 357386, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (7, N'France', N'Paris', 643801, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (8, N'Australia', N'Canberra', 7692024, 6, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (9, N'New Zealand', N'Wellington', 268021, 6, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (10, N'Japan', N'Tokyo', 377972, 1, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (11, N'UAE', N'Abu Dhabi', 83600, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (12, N'Saudi Arabia', N'Riyadh', 2149690, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (13, N'Singapore', N'Singapore', 721.5, 1, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (14, N'South Africa', N'Pretoria', 1221037, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (15, N'Botswana', N'Gaborone', 600370, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (16, N'Namibia', N'Windhoek', 825419, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (17, N'Zimbabwe', N'Harare', 390757, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (18, N'Mozambique', N'Maputo', 801590, 3, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (19, N'Swaziland', N'Mbabane ', 17363, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (20, N'Argentina', N'Buenos Aires', 2780400, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (21, N'Brazil', N'Brasilia', 8515767, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (22, N'Uruguay', N'Montevideo', 176215, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (23, N'Paraguay', N'Asunción', 406752, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (24, N'Bolivia', N'Sucre', 1098581, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (25, N'Chile', N'Santiago', 756950, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (26, N'Peru', N'Lima', 1285216, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (27, N'Ecuador', N'Quito', 283560, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (28, N'Colombia', N'Bogotá', 1141748, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (29, N'Venezuela', N'Caracas', 916445, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (30, N'Guyana', N'Georgetown', 214969, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (31, N'Suriname', N'Paramaribo', 163821, 5, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (32, N'Mexico', N'Mexico City', 1972550, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (33, N'Jamaica', N'Kingston', 10992, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (34, N'Honduras', N'Tegucigalpa', 112492, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (35, N'Haiti', N'Port-au-Prince', 27550, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (36, N'Guatemala', N'Guatemala City', 108888, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (37, N'El Salvador', N'San Salvador', 21041, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (38, N'Dominican Republic', N'Santo Domingo', 48442, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (39, N'Dominica', N'Roseau', 750, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (40, N'Cuba', N'Havana', 109884, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (41, N'Belize', N'Belmopan', 22965, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (42, N'Barbados', N'Bridgetown', 431, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (43, N'Antigua and Barbuda', N'St. John''s', 440, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (44, N'The Bahamas', N'Nassau', 13878, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (45, N'Grenada', N'St. George''s', 348.5, 4, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (46, N'Nicaragua', N'Managua', 130375, 4, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (47, N'Monaco', N'Monaco', 2.02, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (48, N'Portugal', N'Lisbon', 92212, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (49, N'Spain', N'Madrid', 505990, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (50, N'Andorra', N'Andorra la Vella', 467.6, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (51, N'Netherlands', N'Amsterdam', 42508, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (52, N'Belgium', N'Brussels', 30528, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (53, N'Luxembourg', N'Luxembourg', 2585, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (54, N'Switzerland', N'Bern', 41285, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (55, N'Austria', N'Vienna', 83879, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (56, N'Czech Republic', N'Prague', 78865, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (57, N'Greece', N'Athens', 131957, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (58, N'Italy', N'Rome', 301338, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (59, N'Finland', N'Helsinki', 338424, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (60, N'Sweden', N'Stockholm', 450295, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (61, N'Norway', N'Oslo', 385203, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (62, N'Denmark', N'Copenhagen', 42924, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (63, N'Poland', N'Warsaw', 312679, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (64, N'Iceland', N'Reykjavík', 103000, 2, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (65, N'Croatia', N'Zagreb', 56594, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (66, N'San Marino', N'San Marino', 61.2, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (67, N'Liechtenstein', N'Vaduz', 160, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (68, N'Estonia', N'Tallinn', 45226, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (69, N'Latvia', N'Riga', 64589, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (70, N'Lithuania', N'Vilnius', 65300, 2, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (71, N'Madagascar', N'Antananarivo', 586884, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (72, N'Kenya', N'Nairobi', 582644, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (73, N'Uganda', N'Kampala', 241037, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (74, N'Republic of the Congo', N'Brazzaville', 5125821, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (75, N'Democratic Republic of the Congo', N'Kinshasa', 2345409, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (76, N'Lesotho', N'Maseru', 30355, 3, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (77, N'Sri Lanka', N'Sri Jayawardenepura Kotte', 65610, 1, 1, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (78, N'Thailand', N'Bangkok', 513120, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (79, N'South Korea', N'Seoul', 100210, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (80, N'Nepal', N'Kathmandu', 147181, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (81, N'Cambodia', N'Phnom Penh', 181035, 1, 0, 1)
INSERT [dbo].[CountryData] ([CountryId], [CountryName], [CountryCapital], [CountryArea], [ContinentId], [IsIsland], [IsActive]) VALUES (82, N'Bhutan', N'Thimphu', 38394, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[CountryData] OFF
SET IDENTITY_INSERT [dbo].[OverseasTerritoriesData] ON 

INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (1, N' Canary Islands', 4)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (2, N'Gibraltar', 4)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (3, N'Falkland Islands', 4)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (4, N'Turks and Caicos Islands', 4)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (5, N'Aruba', 51)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (6, N'Curaçao', 51)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (7, N'Sint Maarten', 51)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (8, N'Greenland', 62)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (9, N'Faroe Islands', 62)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (10, N'French Guiana', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (11, N'French Polynesia', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (12, N'Guadeloupe', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (13, N'Martinique', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (14, N'Mayotte', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (15, N'New Caledonia', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (16, N'Réunion', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (17, N'Saint Barthélemy', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (18, N'Saint Martin', 7)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (19, N'Andaman and Nicobar Islands', 1)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (20, N'Lakshadweep', 1)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (21, N'Azores', 48)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (22, N'Madeira', 48)
INSERT [dbo].[OverseasTerritoriesData] ([OverseasTerritoriesId], [OverseasTerritoriesName], [CountryId]) VALUES (23, N'Canary Islands', 49)
SET IDENTITY_INSERT [dbo].[OverseasTerritoriesData] OFF
SET IDENTITY_INSERT [dbo].[RoleData] ON 

INSERT [dbo].[RoleData] ([RoleId], [RoleName]) VALUES (1, N'Add')
INSERT [dbo].[RoleData] ([RoleId], [RoleName]) VALUES (2, N'Insert')
INSERT [dbo].[RoleData] ([RoleId], [RoleName]) VALUES (3, N'Update')
INSERT [dbo].[RoleData] ([RoleId], [RoleName]) VALUES (4, N'Delete')
INSERT [dbo].[RoleData] ([RoleId], [RoleName]) VALUES (5, N'View')
SET IDENTITY_INSERT [dbo].[RoleData] OFF
SET IDENTITY_INSERT [dbo].[StateData] ON 

INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (1, N'Gujarat', N'Gandhinagar', 1, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (2, N'Maharashtra', N'Mumbai', 1, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (3, N'Goa', N'Panaji', 1, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (4, N'Karnataka', N'Bangalore', 1, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (5, N'Kerala', N'Thiruvananthapuram', 1, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (6, N'Tamil Nadu', N'Chennai', 1, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (7, N'Eastern Province', N'Dammam', 12, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (8, N'Riyadh', N'Riyadh', 12, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (9, N'Northern', N'Jaffna', 77, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (10, N'Western', N'Colombo', 77, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (11, N'New South Wales', N'Sydney', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (12, N'Queensland', N'Brisbane', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (13, N'South Australia', N'Adelaide', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (14, N'Tasmania', N'Hobart', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (15, N'Victoria', N'Melbourne', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (16, N'Western Australia', N'Perth', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (17, N'Northern Territory', N'Darwin', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (18, N'Australian Capital Territory', N'Canberra', 8, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (19, N'Northland', N'Whangarei', 9, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (20, N'Auckland', N'Auckland', 9, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (21, N'Southland', N'Invercargill', 9, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (22, N'Canterbury', N'Christchurch', 9, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (23, N'Eastern Cape', N'Bhisho', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (24, N'Free State', N'Bloemfontein', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (25, N'Gauteng', N'Johannesburg', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (26, N'KwaZulu-Natal', N'Durban', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (27, N'Limpopo', N'Polokwane', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (28, N'Mpumalanga', N'Mbombela', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (29, N'North West', N'Klerksdorp', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (30, N'Northern Cape', N'Kimberley', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (31, N'Western Cape', N'Cape Town', 14, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (32, N'Khomas Region', N'Windhoek', 16, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (33, N'!Karas Region', N'Keetmanshoop', 16, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (34, N'Bulawayo', N'Bulawayo', 17, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (35, N'Harare', N'Harare', 17, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (36, N'Matabeleland South', N'Gwanda', 17, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (37, N'Santa Fe', N'Santa Fe', 20, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (38, N'Santa Cruz', N'Río Gallegos', 20, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (39, N'Tierra del Fuego', N'Ushuaia', 20, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (40, N'Magallanes Region', N'Punta Arenas', 25, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (41, N'Aysén Region', N'Coyhaique', 25, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (42, N'California', N'Sacramento', 2, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (43, N'Illinois', N'Springfield', 2, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (44, N'Iowa', N'Des Moines', 2, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (45, N'Alaska', N'Anchorage', 2, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (46, N'Georgia', N'Atlanta', 2, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (47, N'Ohio', N'Columbus', 2, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (48, N'Ontario', N'Toronto', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (49, N'Quebec', N'Quebec City', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (50, N'Nova Scotia', N'Halifax', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (51, N'New Brunswick', N'Fredericton', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (52, N'Manitoba', N'Winnipeg', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (53, N'British Columbia', N'Victoria', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (54, N'Prince Edward Island', N'Charlottetown', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (55, N'Saskatchewan', N'Regina', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (56, N'Alberta', N'Edmonton', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (57, N'Newfoundland and Labrador', N'St. John''s', 3, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (58, N'South East', N'Brighton and Hove', 4, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (59, N'London', N'London', 4, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (60, N'North West', N'Manchester', 4, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (61, N'East of England', N'Norwich', 4, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (62, N'Zeeland', N'Middelburg', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (63, N'North Holland', N'Haarlem', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (64, N'Limburg', N'Maastricht', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (65, N'Antwerp', N'Antwerp', 52, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (66, N'Luxembourg', N'Arlon', 52, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (67, N'West Flanders', N'Bruges', 52, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (68, N'Bavaria', N'Munich', 6, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (69, N'Baden-Württemberg', N'Stuttgart', 6, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (70, N'North Rhine-
Westphalia', N'Düsseldorf', 6, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (71, N'Schleswig-Holstein', N' Kiel', 6, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (72, N'North Denmark Region', N'Aalborg', 62, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (73, N'Capital Region of Denmark', N'Hillerød', 62, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (74, N'Central Denmark Region', N'Viborg', 62, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (75, N'Auvergne-Rhône-Alpes', N'Lyon', 7, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (76, N'Pays de la Loire', N'Nantes', 7, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (77, N'Nouvelle-Aquitaine', N'Bordeaux', 7, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (78, N'South Holland', N'The Hague', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (79, N'North Brabant', N'''s-Hertogenbosch', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (80, N'Gelderland', N'Arnhem', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (81, N'Utrecht', N'Utrecht', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (82, N'Flevoland', N'Lelystad', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (83, N'Groningen', N'Groningen', 51, 1)
INSERT [dbo].[StateData] ([StateId], [StateName], [StateCapital], [CountryId], [IsActive]) VALUES (84, N'Overijssel', N'Zwolle', 51, 1)
SET IDENTITY_INSERT [dbo].[StateData] OFF
SET IDENTITY_INSERT [dbo].[UserData] ON 

INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (1, N'Mitesh')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (2, N'Ankita')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (3, N'Adarsh')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (4, N'Jigar')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (5, N'Shripal')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (6, N'Dipal')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (7, N'Kaushal')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (8, N'Priyank')
INSERT [dbo].[UserData] ([UserId], [UserName]) VALUES (9, N'Mohit')
SET IDENTITY_INSERT [dbo].[UserData] OFF
SET IDENTITY_INSERT [dbo].[UserRoleMapping] ON 

INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (1, 1, 1)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (2, 1, 2)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (3, 1, 3)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (4, 2, 4)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (5, 3, 4)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (6, 4, 2)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (7, 4, 4)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (8, 5, 1)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (9, 5, 5)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (10, 5, 4)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (11, 6, 5)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (12, 7, 4)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (13, 7, 5)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (14, 8, 1)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (15, 9, 1)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (16, 9, 2)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (17, 9, 3)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (18, 9, 4)
INSERT [dbo].[UserRoleMapping] ([UserRoleMappingId], [UserId], [RoleId]) VALUES (19, 9, 5)
SET IDENTITY_INSERT [dbo].[UserRoleMapping] OFF
ALTER TABLE [dbo].[CityData]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CityData_dbo.StateData_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[StateData] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CityData] CHECK CONSTRAINT [FK_dbo.CityData_dbo.StateData_StateId]
GO
ALTER TABLE [dbo].[CountryData]  WITH CHECK ADD  CONSTRAINT [FK_CountryData_ContinentData] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[ContinentData] ([ContinentId])
GO
ALTER TABLE [dbo].[CountryData] CHECK CONSTRAINT [FK_CountryData_ContinentData]
GO
ALTER TABLE [dbo].[CountryData]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CountryData_dbo.ContinentData_ContinentId] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[ContinentData] ([ContinentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CountryData] CHECK CONSTRAINT [FK_dbo.CountryData_dbo.ContinentData_ContinentId]
GO
ALTER TABLE [dbo].[OverseasTerritoriesData]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OverseasTerritoriesData_dbo.CountryData_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[CountryData] ([CountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OverseasTerritoriesData] CHECK CONSTRAINT [FK_dbo.OverseasTerritoriesData_dbo.CountryData_CountryId]
GO
ALTER TABLE [dbo].[StateData]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StateData_dbo.CountryData_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[CountryData] ([CountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StateData] CHECK CONSTRAINT [FK_dbo.StateData_dbo.CountryData_CountryId]
GO
ALTER TABLE [dbo].[StateData]  WITH CHECK ADD  CONSTRAINT [FK_StateData_StateData] FOREIGN KEY([CountryId])
REFERENCES [dbo].[CountryData] ([CountryId])
GO
ALTER TABLE [dbo].[StateData] CHECK CONSTRAINT [FK_StateData_StateData]
GO
ALTER TABLE [dbo].[UserRoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRoleMapping_dbo.RoleData_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleData] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoleMapping] CHECK CONSTRAINT [FK_dbo.UserRoleMapping_dbo.RoleData_RoleId]
GO
ALTER TABLE [dbo].[UserRoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRoleMapping_dbo.UserData_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserData] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoleMapping] CHECK CONSTRAINT [FK_dbo.UserRoleMapping_dbo.UserData_UserId]
GO
/****** Object:  StoredProcedure [dbo].[findColumnNameFromAllTables]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[findColumnNameFromAllTables] 
	-- Add the parameters for the stored procedure here
	@strColumnName nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.name AS table_name,
	SCHEMA_NAME(schema_id) AS schema_name,
	c.name AS column_name
	FROM sys.tables AS t
	INNER JOIN sys.columns c ON t.OBJECT_ID = c.OBJECT_ID
	WHERE c.name LIKE '%' + @strColumnName + '%'
	ORDER BY schema_name, table_name; 
	END
GO
/****** Object:  StoredProcedure [dbo].[findTextFromAllObjects]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[findTextFromAllObjects]
	-- Add the parameters for the stored procedure here
	@strText varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT OBJECT_NAME(OBJECT_ID),
	definition
	FROM sys.sql_modules
	WHERE definition LIKE '%' + @strText + '%'
	
END
GO
/****** Object:  StoredProcedure [dbo].[SelectAllCities]    Script Date: 13-03-2019 09:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllCities] 
	-- Add the parameters for the stored procedure here
    @CityName         NVARCHAR(50) = NULL, 
    @IsActive          INT = NULL, 
	@SortBy NVARCHAR(100) = 'CityName',
    @SortOrder NVARCHAR(4) = 'DESC',
	@PageNumber INT, 
	@PageSize INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH CTE AS
	(
	        SELECT *, 
			ROW_NUMBER() OVER( ORDER BY
			CASE WHEN @SortBy = 'CityID' AND @SortOrder = 'ASC' THEN CityID
                END ASC,
            CASE WHEN @SortBy = 'CityID' AND @SortOrder = 'DESC' THEN CityID
                END DESC, 

			CASE WHEN @SortBy = 'CityName' AND @SortOrder = 'ASC' THEN CityName
                END ASC,
            CASE WHEN @SortBy = 'CityName' AND @SortOrder = 'DESC' THEN CityName
                END DESC
		 ) Corr
			FROM CityData
			WHERE
			--(IsActive IS NULL OR IsActive = @IsActive)
        --AND 
		(@CityName IS NULL OR CityName LIKE '%' + @CityName + '%')
			
	)
	SELECT *
	FROM CTE
	WHERE Corr BETWEEN @PageNumber*@PageSize AND @PageNumber*@PageSize+@PageSize-1
END


GO
