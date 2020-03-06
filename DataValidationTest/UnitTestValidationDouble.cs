using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataValidationTest
{
    class UnitTestValidationDouble
    {
        [Test]
        public void ValidRequired()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", (double)12345, "Required");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidRequired()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", (double?)null, "Required");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 1);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidGreaterthan() {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", (double)1236, "GreaterThan(1234)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);


        }

        [Test]
        public void InValidGreaterthan()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", (double?)1233, "GreaterThan(1234)");
            AValidator.AddField("Profile Id", (double?) null, "GreaterThan(1234)");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

            
        }

        [Test]
        public void ValidLessthan()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", (double?)1232, "LessThan(1234)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);


        }

        [Test]
        public void InValidLessthan()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", 1235, "LessThan(1234)");
            AValidator.AddField("Profile Id", (double?)null, "LessThan(1234)");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });


        }

        [Test]
        public void ValidEqual()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", (double?)1234, "Equal(1234)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);


        }

        [Test]
        public void InValidEqual()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Profile Id", 1235, "Equal(1234)");
            AValidator.AddField("Profile Id", (double?)null, "Equal(1234)");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });


        }

        [Test]
        public void ValidRange()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("RemainderBalance", (double?)1, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)5, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)6, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)10, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)-1, "Range(-10,-1)");
            AValidator.AddField("RemainderBalance", (double?)-5, "Range(-10,-1)");
            AValidator.AddField("RemainderBalance", (double?)-6, "Range(-10,-1)");
            AValidator.AddField("RemainderBalance", (double?)-10, "Range(-10,-1)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidRange()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("RemainderBalance", (double?)0, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)11, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)-1, "Range(1,10)");
            AValidator.AddField("RemainderBalance", (double?)1, "Range(-10,-1)");
            AValidator.AddField("RemainderBalance", (double?)null, "Range(1,10)");

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
