using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;



namespace pet_hotel.Models
{
    public enum PetBreedType
    {
        Shepard,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever,
    }

    public enum PetColorType
    {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted,
    }


    public class Pet
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color { get; set; }

        [Required] // do we need Required? or simply use a ? after DateTime
        public DateTime checkedInAt { get; set; }

        [ForeignKey("PetOwners")]
        public int petOwnerId { get; set; }

        public PetOwner ownedBy { get; set; }

    }   
}
