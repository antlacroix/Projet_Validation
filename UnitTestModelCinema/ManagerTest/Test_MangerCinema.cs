using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestModelCinema.ManagerTest
{
    [TestClass]
    public class Test_MangerCinema
    {
        private cinema_dbEntities _context;
        
        [TestInitialize]
        public void Initialize()
        {
            _context = MockDB.cinema_DbEntities();
        }


    }
}
