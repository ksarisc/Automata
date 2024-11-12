using System;
using System.Net.Mail;

namespace Automata.Activities.Notify;

[Operation("Send Email", OperationGroup = OperationGroup.Notify)]
public class SendEmail : IActivity
{
    public string From { get; set; }
    public string To { get; set; }
    public string CC { get; set; }

    public CSharpValue<string>? Subject { get; set; }
    public CSharpValue<string>? Body { get; set; }
    public bool IsHtml { get; set; } = true;

    public CSharpValue<string[]>? Files { get; set; }

    public bool SendImmediately { get; set; }

    private MailMessage BuildMessage(IDependencyFactory factory, IState state)
    {
        //var subject = factory.Evaluate(Subject);
        //var body = factory.Evaluate(Body);

        // build the email data
        var msg = new MailMessage
        {
            From = new MailAddress(from),
        };

        // build recipients/copy list

        return msg;
    }

    public void Run(IDependencyFactory factory, IState state)
    {
        using var msg = BuildMessage(factory, state);

        var path = Path.Combine(state.Path, "Email");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        using var smtp = new SmtpClient("hostname");
        smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        smtp.PickupDirectoryLocation = path;
        smtp.Send(msg);

        if (SendImmediately)
            EmailService.Pickup(path);
    }

    public async Task RunAsync(IDependencyFactory factory, IState state, CancellationToken cancel)
    {
        using var msg = BuildMessage(factory, state);

        var path = Path.Combine(state.Path, "Email");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        using var smtp = new SmtpClient("hostname");
        smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        smtp.PickupDirectoryLocation = path;
        await smtp.SendMailAsync(msg, cancel);

        if (SendImmediately)
            await EmailService.PickupAsync(path, cancel);
    }

    #region cleanup
    protected virtual void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion cleanup
}
