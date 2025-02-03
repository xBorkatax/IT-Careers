using GuideToFlavors.Areas.Identity.Data;
using GuideToFlavors.ServiceModels;

namespace GuideToFlavors.ServiceMappings
{
    public static class GuideToFlavorsUserMapping
    {
        public static GuideToFlavorsUser ToEntity(this GuideToFlavorsUserDto guideToFlavorsUserDto)
        {
            GuideToFlavorsUser guideToFlavorsUser = new GuideToFlavorsUser();

            guideToFlavorsUser.Id = guideToFlavorsUserDto.Id;
            guideToFlavorsUser.UserName = guideToFlavorsUserDto.Username;
            guideToFlavorsUser.FirstName = guideToFlavorsUserDto.FirstName;
            guideToFlavorsUser.LastName = guideToFlavorsUserDto.LastName;

            return guideToFlavorsUser;
        }

        public static GuideToFlavorsUserDto ToDto(this GuideToFlavorsUser guideToFlavorsUser)
        {
            GuideToFlavorsUserDto guideToFlavorsUserDto = new GuideToFlavorsUserDto();

            guideToFlavorsUserDto.Id = guideToFlavorsUser.Id;
            guideToFlavorsUserDto.Username = guideToFlavorsUser.UserName;
            guideToFlavorsUserDto.FirstName = guideToFlavorsUser.FirstName;
            guideToFlavorsUserDto.LastName = guideToFlavorsUser.LastName;

            return guideToFlavorsUserDto;
        }
    }
}
