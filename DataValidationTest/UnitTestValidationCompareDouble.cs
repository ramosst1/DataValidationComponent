using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataValidationTest
{
    class UnitTestValidationCompareDouble
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", (double?)1234, "AccountIdComfirm", (double?)1234, "AreEqual");
            AValidator.AddField("AccountId", (double?)null, "AccountIdComfirm", (double?)null, "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", (double?)1234, "AccountIdComfirm", (double?)12345, "AreEqual");
            AValidator.AddField("AccountId", (double?)1234, "AccountIdComfirm", (double?)null, "AreEqual");
            AValidator.AddField("AccountId", (double?)null, "AccountIdComfirm", (double?)1234, "AreEqual");

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

            AValidator.AddField("AccountId", (double?)1234, "AccountIdComfirm", (double?)12345, "AreNotEqual");
            AValidator.AddField("AccountId", (double?)null, "AccountIdComfirm", (double?)0, "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", (double?)1234, "AccountIdComfirm", (double?)1234, "AreNotEqual");
            AValidator.AddField("AccountId", (double?)null, "AccountIdComfirm", (double?)null, "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidGreaterThanCompare()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", (double?)22, "AgeComfirm", (double?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (double?)22, "AgeComfirm", (double?)-22, "GreaterThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidGreaterThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", (double?)21, "AgeConfirm", (double?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (double?)-21, "AgeConfirm", (double?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (double?)20, "AgeConfirm", (double?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (double?)21, "AgeComfirm", (double?)null, "GreaterThanCompare");
            AValidator.AddField("Age", (double?)null, "AgeComfirm", (double?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (double?)null, "AgeComfirm", (double?)null, "GreaterThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 6);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidLessThanCompare()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", (double?)20, "AgeComfirm", (double?)21, "LessThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidLessThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", (double?)21, "AgeConfirm", (double?)21, "LessThanCompare");
            AValidator.AddField("Age", (double?)21, "AgeConfirm", (double?)-21, "LessThanCompare");
            AValidator.AddField("Age", (double?)21, "AgeConfirm", (double?)20, "LessThanCompare");
            AValidator.AddField("Age", (double?)21, "AgeComfirm", (double?)null, "LessThanCompare");
            AValidator.AddField("Age", (double?)null, "AgeComfirm", (double?)21, "LessThanCompare");
            AValidator.AddField("Age", (double?)null, "AgeComfirm", (double?)null, "LessThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 6);

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
