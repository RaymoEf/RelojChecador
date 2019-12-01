using Microsoft.VisualStudio.TestTools.UnitTesting;
using capaN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaN.Tests
{
    [TestClass()]
    public class NempleadoTests
    {
        [TestMethod()]
        public void InsertarTest()
        {
            var rpta = Nempleado.Insertar("prueba", "unitaria", "test", Convert.ToDateTime("21/07/1999"), "Domicilio Prueba", "5555555555", "H", "RRRRRRRRRR", "RRRRRRRRRR", 500);
            Assert.AreEqual("OK", rpta);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var rpta = Nempleado.Editar(5, "prueba", "unitaria", "test", Convert.ToDateTime("21/07/1999"), "Domicilio Prueba", "5555555555", "H", "RRRRRRRRRR", "RRRRRRRRRR", 500);
            Assert.AreEqual("OK", rpta);
        }
    }
}