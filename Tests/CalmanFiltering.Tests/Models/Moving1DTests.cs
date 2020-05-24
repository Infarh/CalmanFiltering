using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalmanFiltering.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalmanFiltering.Tests.Models
{
    [TestClass]
    public class Moving1DTests : UnitTest
    {
        [TestMethod]
        public void Axeleration_Values_Test()
        {
            var model = new Moving1D();

            Assert.That.Value(model.Axeleration(model.t1)).IsEqual(0.997, 3.57e-004);
            Assert.That.Value(model.Axeleration(model.t2)).IsEqual(-1.995d, 2.90e-004);

            Func<double, double> axeleration = model.Axeleration;
            var speed = axeleration.GetIntegral(model.ModelingTime.Min);
            var movment = speed.GetIntegral(model.ModelingTime.Min);

            Assert.That.Value(speed(model.ModelingTime.Max)).IsEqual(0, 1.86e-008);
            Assert.That.Value(movment(model.ModelingTime.Max)).IsEqual(60, 2.79e-006);
        }

        [TestMethod]
        public void GetMovement_Result_Test()
        {
            var model = new Moving1D();

            var movement = model
               .GetMovement(model.ModelingTime.Max, StartTime: model.ModelingTime.Min);

            Assert.That.Value(movement.Time)
               .Where(time => time.Start).Check(start_time => start_time.IsEqual(model.ModelingTime.Min))
               .Where(time => time.End).Check(end_time => end_time.IsEqual(model.ModelingTime.Max));

            Assert.That.Value(movement.Position)
               .Where(pos => pos.Start).Check(start_pos => start_pos.IsEqual(0))
               .Where(pos => pos.End).Check(end_pos => end_pos.IsEqual(60, 1.49e-007));
        }

        [TestMethod]
        public void TrimByStartTime_0_Test()
        {
            var model = new Moving1D();

            var movement = model
               .GetMovement(model.ModelingTime.Max, StartTime: model.ModelingTime.Min)
               .TrimByStartTime(0);

            Assert.That.Value(movement.Time.Start).IsEqual(0);
        }
    }
}
