﻿using Microsoft.AspNetCore.Mvc;
using Rekenmachine.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Rekenmachine_tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [TestCase(2, 3, "optellen", 5)]
        [TestCase(5, 3, "aftrekken", 2)]
        [TestCase(4, 5, "vermenigvuldigen", 20)]
        [TestCase(6, 2, "delen", 3)]
        public void TestBereken(double num1, double num2, string bewerking, double verwachtResultaat)
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var resultaat = controller.Bereken(num1, num2, bewerking) as ViewResult;

            // Assert
            Assert.That(resultaat.ViewData["Resultaat"], Is.EqualTo(verwachtResultaat));
        }

        [Test]
        public void TestNaamOmgekeerd()
        {
            // Arrange
            var controller = new HomeController();
            string naam = "Robocop";

            // Act
            var resultaat = controller.NaamOmgekeerd(naam) as ViewResult;

            // Assert
            Assert.That(resultaat, Is.Not.Null);
            Assert.That(resultaat.ViewData["OmgekeerdeNaam"], Is.EqualTo("pocoboR"));
        }

        [TestCase(49, "Proficiat, u bent een van de weinige die niet te hard rijdt!")]
        [TestCase(50, "Proficiat, u bent een van de weinige die niet te hard rijdt!")]
        [TestCase(51, "Foei, u krijgt een boete van €150")]
        [TestCase(55, "Foei, u krijgt een boete van €250")]
        public void TestBoete(int snelheid, string verwachtResultaat)
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var resultaat = controller.Boete(snelheid) as ViewResult;

            // Assert
            Assert.That(resultaat, Is.Not.Null);
            Assert.That(resultaat.ViewData["BoeteResultaat"], Is.EqualTo(verwachtResultaat));
        }
    }
}