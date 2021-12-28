USE [reloj2]
GO

/****** Object:  Table [dbo].[salida_empleados]    Script Date: 27/11/2019 16:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[salida_empleados](
	[id_empleado] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC,
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[salida_empleados]  WITH CHECK ADD  CONSTRAINT [FK_salida_empleados_empleados] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[empleados] ([id_empleado])
GO

ALTER TABLE [dbo].[salida_empleados] CHECK CONSTRAINT [FK_salida_empleados_empleados]
GO

