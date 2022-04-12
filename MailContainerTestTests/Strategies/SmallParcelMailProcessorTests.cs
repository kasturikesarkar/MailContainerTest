using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailContainerTest.Types;

namespace MailContainerTest.Strategies.Tests;

[TestClass()]
public class SmallParcelMailProcessorTests
{
    [TestMethod()]
    public void ShouldReturnFalse_WhenSmallParcelMailContainerIsNull()
    {
        // Arrange
        MailContainer mailContainer = null;
        var smallParcelMailProcessor = new SmallParcelMailProcessor();

        // Act
        var result = smallParcelMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnFalse_WhenNotSmallParcelMail()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.StandardLetter;
        var smallParcelMailProcessor = new SmallParcelMailProcessor();

        // Act
        var result = smallParcelMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnFalse_WhenMailContainerStatusNotOperational()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
        mailContainer.Status = MailContainerStatus.OutOfService;
        var smallParcelMailProcessor = new SmallParcelMailProcessor();

        // Act
        var result = smallParcelMailProcessor.IsSuccessfull(mailContainer, 2);

        // Assert
        Assert.AreEqual(result, false);
    }

    [TestMethod()]
    public void ShouldReturnTrue_WhenSmallParcelMail()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
        var smallParcelMailProcessor = new SmallParcelMailProcessor();

        // Act
        var result = smallParcelMailProcessor.IsSuccessfull(mailContainer, 0);

        // Assert
        Assert.AreEqual(result, true);
    }

    [TestMethod()]
    public void ShouldReturnTrue_WhenMailContainerStatusOperational()
    {
        // Arrange
        MailContainer mailContainer = new MailContainer();
        mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
        mailContainer.Status = MailContainerStatus.Operational;
        var smallParcelMailProcessor = new SmallParcelMailProcessor();

        // Act
        var result = smallParcelMailProcessor.IsSuccessfull(mailContainer, 2);

        // Assert
        Assert.AreEqual(result, true);
    }
}
