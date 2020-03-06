using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DataValidationTest
{
    public class UnitTestValidationString
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidRequired()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("FirstName", "Steven", "Required");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidRequired()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("FirstName", "", "Required");
            AValidator.AddField("FirstName", " ", "Required");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidEmail()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("User Email", "ramosst@aol.com", "IsEmail");
            AValidator.AddField("User Email", "ramosst@aol.comic", "IsEmail");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidEmail()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("User Email", "ramosst.com", "IsEmail");
            AValidator.AddField("User Email", "streven@ramosst", "IsEmail");
            AValidator.AddField("User Email", "streven", "IsEmail");
            AValidator.AddField("User Email", "@", "IsEmail");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 4);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidUserName()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("User Name", "Ramosst70", "IsUserName");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidIsUserName()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("User Name", "Ramosst7", "IsUserName");
            AValidator.AddField("User Name", "ramosstmyuser", "IsUserName");
            AValidator.AddField("User Name", "Ramosst7XXXXXXXX", "IsUserName");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 3);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidAlphaCharOnly()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("StateAbrev", "Ny", "AlphaCharOnly");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidAlphaCharOnly()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("StateAbrev", "NY1", "AlphaCharOnly");
            AValidator.AddField("StateAbrev", "1NY", "AlphaCharOnly");
            AValidator.AddField("StateAbrev", "N1Y", "AlphaCharOnly");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 3);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidNumbersOnly()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", "10", "NumbersOnly");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidNumbersOnly()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Age", "10a", "NumbersOnly");
            AValidator.AddField("Age", "a10", "NumbersOnly");
            AValidator.AddField("Age", "1a0", "NumbersOnly");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 3);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });


        }

        [Test]
        public void ValidPassword()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Password", "RamosSte10", "Password");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidPassword()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Password", "JoeSmith10!", "Password");
            AValidator.AddField("Password", "JoeSmit", "Password");
            AValidator.AddField("Password", "", "Password");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 3);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });


        }

        [Test]
        public void ValidLengthMin()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("ZipCode", "12345", "LengthMin(5)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidLengthMin()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("ZipCode", "1234", "LengthMin(5)");
            AValidator.AddField("ZipCode", "", "LengthMin(5)");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 2);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }
        [Test]
        public void ValidLengthMax()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("ZipCode", "12345", "LengthMax(5)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }
        [Test]
        public void InValidLengthMax()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("ZipCode", "12345678", "LengthMax(7)");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 1);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }

        [Test]
        public void ValidZipCode()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("ZipCode", "12345", "Required;NumOnly;LengthMin(5);LengthMax(5)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidZipcode()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("ZipCode", "1234", "NumbersOnly;LengthMin(5);LengthMax(5)");
            AValidator.AddField("ZipCode", "123456", "NumbersOnly;LengthMin(5);LengthMax(5)");
            AValidator.AddField("ZipCode", "12a45", "NumbersOnly;LengthMin(5);LengthMax(5)");
            AValidator.AddField("ZipCode", "abcde", "NumbersOnly;LengthMin(5);LengthMax(5)");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 4);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

            Assert.IsTrue(Messages.Exists(aItem => aItem.FieldName.Equals("ZipCode")), "The Zip code is valid.");


        }

        [Test]
        public void ValidAlphaNumericOnly()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("UniqueProfileId", "12345abcd", "AlphaNumericOnly");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidAlphaNumericOnly()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("UniqueProfileId", "12345abcd!", "AlphaNumericOnly");
            AValidator.AddField("UniqueProfileId", "12345!", "AlphaNumericOnly");
            AValidator.AddField("UniqueProfileId", "!12345", "AlphaNumericOnly");
            AValidator.AddField("UniqueProfileId", "123!45", "AlphaNumericOnly");
            AValidator.AddField("UniqueProfileId", "abc!", "AlphaNumericOnly");
            AValidator.AddField("UniqueProfileId", "!abc", "AlphaNumericOnly");
            AValidator.AddField("UniqueProfileId", "a|bc", "AlphaNumericOnly");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 7);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidIsCurrency()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AmountDue", "12345", "IsCurrency");
            AValidator.AddField("AmountDue", "12345.23", "IsCurrency");
            AValidator.AddField("AmountDue", "-12345", "IsCurrency");
            AValidator.AddField("AmountDue", "-12345.23", "IsCurrency");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidIsCurrency()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AmountDue", "12345a", "IsCurrency");
            AValidator.AddField("AmountDue", "12345.23a", "IsCurrency");
            AValidator.AddField("AmountDue", "12345.123", "IsCurrency");
            AValidator.AddField("AmountDue", "12345A", "IsCurrency");
            AValidator.AddField("AmountDue", "A12345", "IsCurrency");
            AValidator.AddField("AmountDue", "1A2345", "IsCurrency");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 6);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });



        }

        [Test]
        public void ValidIsDate()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("AmountDue", "12/30/2020", "IsDate(MM/dd/yyyy)");
            AValidator.AddField("AmountDue", "1/2/2020", "IsDate(M/d/yyyy)");

            var Messages = AValidator.Validate();

            Assert.IsEmpty(Messages);

            WriteToConsole(Messages);

        }

        [Test]
        public void InValidIsDate()
        {

            var AValidator = new DataValidation.Validator();

            AValidator.AddField("Expiration Date", "02/30/2020", "IsDate(MM/dd/yyyy)");
            AValidator.AddField("Expiration Date", "02/29/20", "IsDate(MM/dd/yyyy)");
            AValidator.AddField("Expiration Date", "ab/29/2020", "IsDate(MM/dd/yyyy)");
            AValidator.AddField("Expiration Date", "02/ab/2020", "IsDate(MM/dd/yyyy)");
            AValidator.AddField("Expiration Date", "02/29/abcd", "IsDate(MM/dd/yyyy)");
            AValidator.AddField("Expiration Date", "a/29/2020", "IsDate(M/dd/yyyy)");
            AValidator.AddField("Expiration Date", "02/a/2020", "IsDate(MM/d/yyyy)");
            AValidator.AddField("Expiration Date", "02/29/abcd", "IsDate(MM/dd/yyyy");

            var Messages = AValidator.Validate();

            WriteToConsole(Messages);

            Assert.AreEqual(Messages.Count, 8);

            Messages.ForEach(delegate (DataValidation.IValidationMessage message)
            {
                StringAssert.DoesNotContain(message.ErrorMessage, message.FieldName);
            });

        }


        private void  WriteToConsole(List <DataValidation.IValidationMessage> messages) {

            messages.ForEach(delegate (DataValidation.IValidationMessage aMessage)
            {
                System.Diagnostics.Debug.WriteLine(aMessage.ErrorMessage);
            });
        }

    }
}