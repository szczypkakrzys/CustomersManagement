using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Application.Features.Client.Queries.GetClientDetails;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using MediatR;

namespace CustomersManagement.Application.Features.Documents.Commands.FillDocument;

public class FillDocumentCommandHandler : IRequestHandler<FillDocumentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IAppLogger<FillDocumentCommandHandler> _logger;

    public FillDocumentCommandHandler(
        IMapper mapper,
        IMediator mediator,
        IAppLogger<FillDocumentCommandHandler> logger)
    {
        _mapper = mapper;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<Unit> Handle(
        FillDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var clientDetails = await _mediator.Send(new GetClientDetailsQuery(request.UserId)) ??
            throw new NotFoundException(nameof(Client), request.UserId);
        try
        {
            //todo implement logic to fill document forms
            var filePath = Path.Combine("C:\\Users\\Krzysiek\\repos\\CustomersManagement\\src\\TmpFilesStore\\Templates", request.FileName);

            if (File.Exists(filePath))
            {
                //var sourceStream = File.OpenRead(filePath);

                var clientDirectory = Path.Combine("C:\\Users\\Krzysiek\\repos\\CustomersManagement\\src\\TmpFilesStore", clientDetails.EmailAddress);
                if (!Directory.Exists(clientDirectory))
                    Directory.CreateDirectory(clientDirectory);

                var outputFilePath = Path.Combine(clientDirectory, request.FileName);
                using (var sourceStream = File.OpenRead(filePath))
                {
                    using (var outputStream = File.Create(outputFilePath))
                    {
                        var document = new PdfDocument(new PdfReader(sourceStream), new PdfWriter(outputStream));
                        var form = PdfAcroForm.GetAcroForm(document, false);

                        if (form != null)
                        {
                            var fields = form.GetRootFormFields();
                            PdfFormField fieldValue;

                            fields.TryGetValue("FirstName Text Box", out fieldValue);
                            fieldValue.SetValue(clientDetails.FirstName);

                            fields.TryGetValue("LastName Text Box", out fieldValue);
                            fieldValue.SetValue(clientDetails.LastName);

                            fields.TryGetValue("EmailAddress Text Box", out fieldValue);
                            fieldValue.SetValue(clientDetails.EmailAddress);

                            document.Close();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //todo
            //custom exception + logger
            throw new Exception(ex.Message);
        }

        return Unit.Value;
    }




}