using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataValidationTest
{
    class UnitTestValidationCompareLong
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", (long?)1234, "AccountIdComfirm", (long?)1234, "AreEqual");
            AValidator.AddField("AccountId", (long?)null, "AccountIdComfirm", (long?)null, "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", (long?)1234, "AccountIdComfirm", (long?)12345, "AreEqual");
            AValidator.AddField("AccountId", (long?)1234, "AccountIdComfirm", (long?)null, "AreEqual");
            AValidator.AddField("AccountId", (long?)null, "AccountIdComfirm", (long?)1234, "AreEqual");

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

            AValidator.AddField("AccountId", (long?)1234, "AccountIdComfirm", (long?)12345, "AreNotEqual");
            AValidator.AddField("AccountId", (long?)null, "AccountIdComfirm", (long?)0, "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", (long?)1234, "AccountIdComfirm", (long?)1234, "AreNotEqual");
            AValidator.AddField("AccountId", (long?)null, "AccountIdComfirm", (long?)null, "AreNotEqual");

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

            AValidator.AddField("Age", (long?)22, "AgeComfirm", (long?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (long?)22, "AgeComfirm", (long?)-22, "GreaterThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidGreaterThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", (long?)21, "AgeConfirm", (long?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (long?)-21, "AgeConfirm", (long?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (long?)20, "AgeConfirm", (long?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (long?)21, "AgeComfirm", (long?)null, "GreaterThanCompare");
            AValidator.AddField("Age", (long?)null, "AgeComfirm", (long?)21, "GreaterThanCompare");
            AValidator.AddField("Age", (long?)null, "AgeComfirm", (long?)null, "GreaterThanCompare");

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

            AValidator.AddField("Age", (long?)20, "AgeComfirm", (long?)21, "LessThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidLessThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", (long?)21, "AgeConfirm", (long?)21, "LessThanCompare");
            AValidator.AddField("Age", (long?)21, "AgeConfirm", (long?)-21, "LessThanCompare");
            AValidator.AddField("Age", (long?)21, "AgeConfirm", (long?)20, "LessThanCompare");
            AValidator.AddField("Age", (long?)21, "AgeComfirm", (long?)null, "LessThanCompare");
            AValidator.AddField("Age", (long?)null, "AgeComfirm", (long?)21, "LessThanCompare");
            AValidator.AddField("Age", (long?)null, "AgeComfirm", (long?)null, "LessThanCompare");

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
