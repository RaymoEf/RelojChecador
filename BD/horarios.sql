USE [reloj2]
GO

/****** Object:  Table [dbo].[horarios]    Script Date: 27/11/2019 16:56:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[horarios](
	[id_empleado] [int] NOT NULL,
	[hora_entrada] [time](7) NOT NULL,
	[inicio_entrada] [time](7) NOT NULL,
	[fin_entrada] [time](7) NOT NULL,
	[inicio_salida] [time](7) NOT NULL,
	[fin_salida] [time](7) NOT NULL,
 CONSTRAINT [PK_horarios] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[horarios]  WITH CHECK ADD  CONSTRAINT [FK_horarios_empleados] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[empleados] ([id_empleado])
GO

ALTER TABLE [dbo].[horarios] CHECK CONSTRAINT [FK_horarios_empleados]
GO

