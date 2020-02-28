using MCUWebAPPTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCURelationalTest
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string RealName { get; set; }
        public string AlterEgo { get; set; }
    }

    public class CharacterMovie
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Character Character { get; set; }

    }

    public class MovieCreate
    {
        public string Title { get; set; }
    }
    public class CharacterCreate
    {
        public string RealName { get; set; }
        public string AlterEgo { get; set; }
    }

    public class MovieListItem
    {
        public string Title { get; set; }
    }

    public class CharacterDetail
    {
        public string RealName { get; set; }
        public string AlterEgo { get; set; }
        public IEnumerable<MovieListItem> Movies { get; set; }
    }

    public class CharacterMovieCreate
    {
        public int MovieId { get; set; }
        public int CharacterId { get; set; }

    }
    public class CharacterMovieListItem
    {
        public int MovieId { get; set; }
        public int CharacterId { get; set; }
    }


}
