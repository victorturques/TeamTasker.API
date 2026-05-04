using FluentValidation;
using TeamTasker.API.DTOs; // Ajuste para o seu namespace correto

namespace TeamTasker.API.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            // Exemplo de regras (ajuste de acordo com as propriedades reais do seu DTO)
            RuleFor(task => task.Title)
                .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
                .MinimumLength(3).WithMessage("O título deve ter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O título não pode exceder 100 caracteres.");

            RuleFor(task => task.Description)
                .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");

            // Se você tiver uma data de entrega, pode garantir que não seja no passado:
            // RuleFor(task => task.DueDate)
            //    .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de entrega não pode estar no passado.");
        }
    }
}