using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataValidationTest
{
    class UnitTestValidationCompareDateTime
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/02/2020");
            var SameDateB = DateTime.Parse("03/02/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "AreEqual");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", (DateTime?)null, "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/02/2020");
            var SameDateB = DateTime.Parse("03/03/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "AreEqual");
            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", (DateTime?)null, "AreEqual");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", SameDateB, "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 3);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/02/2020");
            var SameDateB = DateTime.Parse("03/03/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "AreNotEqual");
            AValidator.AddField("CreatedDate", SameDateB, "CreatedDateComfirm", SameDateA, "AreNotEqual");
            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", (DateTime?)null, "AreNotEqual");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", SameDateB, "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/02/2020");
            var SameDateB = DateTime.Parse("03/02/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "AreNotEqual");
            AValidator.AddField("CreatedDate", SameDateB, "CreatedDateComfirm", SameDateA, "AreNotEqual");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", (DateTime?)null, "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 3);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidGreaterThanCompare()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/03/2020");
            var SameDateB = DateTime.Parse("03/02/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "GreaterThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidGreaterThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/03/2020");
            var SameDateB = DateTime.Parse("03/03/2020");
            var SameDateC = DateTime.Parse("03/04/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "GreaterThanCompare");
            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateC, "GreaterThanCompare");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", (DateTime?)null, "GreaterThanCompare");
            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", (DateTime?)null, "GreaterThanCompare");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", SameDateB, "GreaterThanCompare");


            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 5);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidLessThanCompare()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/02/2020");
            var SameDateB = DateTime.Parse("03/03/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "LessThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidLessThanCompare()
        {
            var AValidator = new DataValidation.Validator();

            var SameDateA = DateTime.Parse("03/05/2020");
            var SameDateB = DateTime.Parse("03/05/2020");
            var SameDateC = DateTime.Parse("03/04/2020");

            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateB, "LessThanCompare");
            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", SameDateC, "LessThanCompare");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", (DateTime?)null, "LessThanCompare");
            AValidator.AddField("CreatedDate", SameDateA, "CreatedDateComfirm", (DateTime?)null, "LessThanCompare");
            AValidator.AddField("CreatedDate", (DateTime?)null, "CreatedDateComfirm", SameDateB, "LessThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 5);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        private void WriteToConsole(List<DataValidation.IValidationMessage> messages)
        {

            messages.ForEach(delegate (DataValidation.IValidationMessage aMessage)
            {
                System.Diagnostics.Debug.WriteLine(aMessage.ErrorMessage);
            });
        }

    }
}
