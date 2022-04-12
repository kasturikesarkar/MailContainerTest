using MailContainerTest.Types;

namespace MailContainerTest.Strategies;

public class SmallParcelMailProcessor : IMailProcessor
{
    public bool IsSuccessfull(MailContainer mailContainer, int numberOfMailItems)
    {
        if (mailContainer == null)
        {
            return false;
        }
        else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
        {
            return false;

        }
        else if (mailContainer.Status != MailContainerStatus.Operational)
        {
            return false;
        }
        return true;
    }
}
