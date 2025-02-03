using BarRating.Data.Models;
using BarRating.Service.Models;

namespace BarRating.Service.Mappings
{
    public static class BarRatingUserMapping
    {
        public static BarRatingUser ToEntity(this BarRatingUserDto barRatingUserDto)
        {
            BarRatingUser barRatingUser = new BarRatingUser();

            barRatingUser.Id = barRatingUserDto.Id;
            barRatingUser.UserName = barRatingUserDto.UserName;
            barRatingUser.FirstName = barRatingUserDto.FirstName;
            barRatingUser.LastName = barRatingUserDto.LastName;

            return barRatingUser;
        }

        public static BarRatingUserDto ToDto(this BarRatingUser barRatingUser)
        {
            BarRatingUserDto barRatingUserDto = new BarRatingUserDto();

            barRatingUserDto.Id = barRatingUser.Id;
            barRatingUserDto.UserName = barRatingUser.UserName;
            barRatingUserDto.FirstName = barRatingUser.FirstName;
            barRatingUserDto.LastName = barRatingUser.LastName;

            return barRatingUserDto;
        }
    }
}
