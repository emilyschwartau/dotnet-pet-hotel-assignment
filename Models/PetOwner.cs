using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pet_hotel.Models
{
    public class PetOwner
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        //validated format?
        public string email { get; set; }

        // this is ignoring putting the petList into the DB table; not a DB column but a dynamic created field to get the pet count;
        [JsonIgnore]
        public List<Pet> petList { get; set; }

        [NotMapped]
        public int petCount
        {
            get
            {
                return (this.petList != null ? this.petList.Count : 0);
            }
        }


    }
}
