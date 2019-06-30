using System.ComponentModel.DataAnnotations;

namespace MarsRover.Enums
{
    public enum OrientationEnum
    {
        [Display(Name ="N")]
        North = 1,
        [Display(Name ="W")]
        West = 2,           
        [Display(Name ="S")]
        South = 3,          
        [Display(Name ="E")]
        East = 4
    }
}
