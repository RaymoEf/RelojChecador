USE [reloj2]
GO

/****** Object:  Table [dbo].[empleados]    Script Date: 27/11/2019 16:50:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[empleados](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido_paterno] [varchar](50) NOT NULL,
	[apellido_materno] [varchar](50) NOT NULL,
	[fecha_nac] [date] NULL,
	[domicilio] [varchar](100) NULL,
	[telefono] [varchar](15) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[curp] [varchar](20) NOT NULL,
	[rfc] [varchar](20) NOT NULL,
	[salario_dia] [money] NOT NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

