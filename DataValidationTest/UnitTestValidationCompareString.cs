using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidationTest
{
    class UnitTestValidationCompareString
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", "ABC123", "AccountIdComfirm", "ABC123", "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", "ABC123", "AccountIdComfirm", "ABC1234", "AreEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 1);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", "ABC123", "AccountIdComfirm", "ABC1234", "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidAreNotEqual()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AccountId", "ABC123", "AccountIdComfirm", "ABC123", "AreNotEqual");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 1);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }
        [Test]
        public void ValidExact()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Password", "MyPassword", "PasswordComfirm", "MyPassword", "Exact");

            var Messages = AValidator.Validate();


            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidExact()
        {
            var AValidator = new DataValidation.Validator();


            AValidator.AddField("Password", "MyPassword", "PasswordComfirm", "MyPasswordX", "Exact");
            AValidator.AddField("Password", "MyPassword", "PasswordComfirm", "mypassword", "Exact");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidNotExact()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Password", "MyPassword", "PasswordComfirm", "MyPasswordX", "NotExact");

            var Messages = AValidator.Validate();


            WriteToConsole(Messages);

            Assert.IsEmpty(Messages);

        }

        [Test]
        public void InValidNotExact()
        {
            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Password", "MyPassword", "PasswordComfirm", "MyPassword", "NotExact");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 1);

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
