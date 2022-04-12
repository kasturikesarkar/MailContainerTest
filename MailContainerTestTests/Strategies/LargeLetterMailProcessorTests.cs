using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailContainerTest.Types;

namespace MailContainerTest.Strategies.Tests;

[TestClass()]
public class LargeLetterMailProcessorTests
{
    [TestMethod()]
    public void ShouldReturnFalse_WhenLargeLetterMailContainerIsNull()
    {
        // Arrange
        MailContainer mailContainer = null;
        var largeLetterMailProcessor = new LargeLetterMailProcessor();

        // Act
        var result = largeLetterMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnFalse_WhenNotLargeLetterMail()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.StandardLetter;
        var largeLetterMailProcessor = new LargeLetterMailProcessor();

        // Act
        var result = largeLetterMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnFalse_WhenMailContainerCapacityLessThanNumberOfMailItems()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
        mailContainer.Capacity = 2;
        var largeLetterMailProcessor = new LargeLetterMailProcessor();

        // Act
        var result = largeLetterMailProcessor.IsSuccessfull(mailContainer, 4);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnTrue_WhenLargeLetterMail()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
        var largeLetterMailProcessor = new LargeLetterMailProcessor();

        // Act
        var result = largeLetterMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, true);
    }

    [TestMethod()]
    public void ShouldReturnTrue_WhenMailContainerCapacityEqualToNumberOfMailItems()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
        mailContainer.Capacity = 2;
        var largeLetterMailProcessor = new LargeLetterMailProcessor();

        // Act
        var result = largeLetterMailProcessor.IsSuccessfull(mailContainer, 2);

        // Assert
        Assert.AreEqual(result, true);
    }

    [TestMethod()]
    public void ShouldReturnTrue_WhenMailContainerCapacityGreaterThanNumberOfMailItems()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
        mailContainer.Capacity = 4;
        var largeLetterMailProcessor = new LargeLetterMailProcessor();

        // Act
        var result = largeLetterMailProcessor.IsSuccessfull(mailContainer, 2);

        // Assert
        Assert.AreEqual(result, true);
    }
}
