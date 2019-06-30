using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum MovementEnum
    {
        [Display(Name = "L")]
        Left,
        [Display(Name = "R")]
        Right,
        [Display(Name = "M")]
        Move
    }
}
