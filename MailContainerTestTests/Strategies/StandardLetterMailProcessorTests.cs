using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailContainerTest.Types;

namespace MailContainerTest.Strategies.Tests;

[TestClass()]
public class StandardLetterMailProcessorTests
{
    [TestMethod()]
    public void ShouldReturnFalse_WhenStandardLetterMailContainerIsNull()
    {
        // Arrange
        MailContainer mailContainer = null;
        var standardLetterMailProcessor = new StandardLetterMailProcessor();

        // Act
        var result = standardLetterMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnFalse_WhenNotStandardLetterMail()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
        var standardLetterMailProcessor = new StandardLetterMailProcessor();

        // Act
        var result = standardLetterMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnTrue_WhenStandardLetterMail()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.StandardLetter;
        var standardLetterMailProcessor = new StandardLetterMailProcessor();

        // Act
        var result = standardLetterMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, true);
    }
}
