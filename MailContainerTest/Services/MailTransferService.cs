using MailContainerTest.Data;
using MailContainerTest.Factories;
using MailContainerTest.Strategies;
using MailContainerTest.Types;
using System.Collections.Generic;
using System.Configuration;

namespace MailContainerTest.Services;

public class MailTransferService : IMailTransferService
{
    Dictionary<MailType, IMailProcessor> strategies = new Dictionary<MailType, IMailProcessor>();
    MailContainerDataStoreFactory mailContainerDataStoreFactory;

    public MailTransferService()
    {
        mailContainerDataStoreFactory = new MailContainerDataStoreFactory();
        strategies.Add(MailType.StandardLetter, new StandardLetterMailProcessor());
        strategies.Add(MailType.LargeLetter, new LargeLetterMailProcessor());
        strategies.Add(MailType.SmallParcel, new SmallParcelMailProcessor());
    }

    public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
    {
        var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

        var mailContainerDataStore = mailContainerDataStoreFactory.CreateDataStore(dataStoreType!);
        MailContainer mailContainer = mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

        var result = new MakeMailTransferResult();

        strategies.TryGetValue(request.MailType, out var mailProcessor);

        result.Success = mailProcessor!.IsSuccessfull(mailContainer, request.NumberOfMailItems);

        if (result.Success)
        {
            mailContainer.Capacity -= request.NumberOfMailItems;
            mailContainerDataStore.UpdateMailContainer(mailContainer);
        }
        return result;
    }
}
