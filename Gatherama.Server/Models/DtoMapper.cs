using Gatherama.Shared;

namespace Gatherama.Server.Models
{
    public static class DtoMapper
    {
        public static FindingDto ToDto(this Finding finding)
        {
            return new FindingDto
            {
                Id = finding.Id,
                _private = finding._private,
                datetime = finding.datetime,
                amount = finding.amount,
                memo = finding.memo,
            };
        }
        public static FriendshipDto ToDto(this Friendship friendship)
        {
            return new FriendshipDto
            {
                Id = friendship.Id,
                friend_request = friendship.friend_request,
                friend_accept = friendship.friend_accept,

            };
        }
        public static MediaDto ToDto(this Media media)
        {
            return new MediaDto
            {
                Id = media.Id,
                mediaLocation = media.mediaLocation,
                photo = media.photo,
            };
        }
        public static PersonDto ToDto(this Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                firstName = person.firstName,
                lastName = person.lastName,
                username = person.username,
                email = person.email,
                password = person.password,

            };
        }
        public static PlaceDto ToDto(this Place place)
        {
            return new PlaceDto
            {
                Id = place.Id,
                city = place.city,
                country = place.country,
                lat = place.lat,
                lng = place.lng,
            };
        }
        public static SpeciesDto ToDto(this Species species)
        {
            return new SpeciesDto
            {
                Id = species.Id,
                category = species.category,
                subCategory = species.subCategory,
                s_name = species.s_name,
                latin_name = species.latin_name,
            };
        }
    }
}
