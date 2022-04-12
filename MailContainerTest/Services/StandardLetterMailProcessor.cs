using MailContainerTest.Types;

namespace MailContainerTest.Strategies;

public class StandardLetterMailProcessor : IMailProcessor
{
    public bool IsSuccessfull(MailContainer mailContainer, int numberOfMailItems)
    {
        if (mailContainer == null)
        {
            return false;
        }
        else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
        {
            return false;
        }
        return true;
    }
}
