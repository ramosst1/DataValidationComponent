using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataValidationTest
{
    class UnitTestValidationCompareInt
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", 1234, "AccountIdComfirm", 1234, "AreEqual");
            AValidator.AddField("AccountId", (int?)null, "AccountIdComfirm", (int?)null, "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", 1234, "AccountIdComfirm", 12345, "AreEqual");
            AValidator.AddField("AccountId", 1234, "AccountIdComfirm", (int?)null, "AreEqual");
            AValidator.AddField("AccountId", (int?)null, "AccountIdComfirm", 1234, "AreEqual");

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

            AValidator.AddField("AccountId", 1234, "AccountIdComfirm", 12345, "AreNotEqual");
            AValidator.AddField("AccountId", (int?)null, "AccountIdComfirm", 0, "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", 1234, "AccountIdComfirm", 1234, "AreNotEqual");
            AValidator.AddField("AccountId", (int?)null, "AccountIdComfirm", (int?)null, "AreNotEqual");

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

            AValidator.AddField("Age", 22, "AgeComfirm", 21, "GreaterThanCompare");
            AValidator.AddField("Age", 22, "AgeComfirm", -22, "GreaterThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidGreaterThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", 21, "AgeConfirm", 21, "GreaterThanCompare");
            AValidator.AddField("Age", -21, "AgeConfirm", 21, "GreaterThanCompare");
            AValidator.AddField("Age", 20, "AgeConfirm", 21, "GreaterThanCompare");
            AValidator.AddField("Age", 21, "AgeComfirm", (int?)null, "GreaterThanCompare");
            AValidator.AddField("Age", (int?)null, "AgeComfirm", 21, "GreaterThanCompare");
            AValidator.AddField("Age", (int?)null, "AgeComfirm", (int?)null, "GreaterThanCompare");

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

            AValidator.AddField("Age", 20, "AgeComfirm", 21, "LessThanCompare");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidLessThanComparel()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", 21, "AgeConfirm", 21, "LessThanCompare");
            AValidator.AddField("Age", 21, "AgeConfirm", -21, "LessThanCompare");
            AValidator.AddField("Age", 21, "AgeConfirm", 20, "LessThanCompare");
            AValidator.AddField("Age", 21, "AgeComfirm", (int?)null, "LessThanCompare");
            AValidator.AddField("Age", (int?)null, "AgeComfirm", 21, "LessThanCompare");
            AValidator.AddField("Age", (int?)null, "AgeComfirm", (int?)null, "LessThanCompare");

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
