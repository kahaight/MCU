using MCURelationalTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCUWebAPPTest.Models
{
    public class ClassesService
    {
        public bool CreateMovie(MovieCreate model)
        {
            var entity = new Movie()
            {
                Title = model.Title
            };
            using (var ctx = new ClassesDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateCharacter(CharacterCreate model)
        {
            var entity = new Character()
            {
                RealName = model.RealName,
                AlterEgo = model.AlterEgo
            };
            using (var ctx = new ClassesDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateCharacterMovie(CharacterMovieCreate model)
        {
            var entity = new CharacterMovie()
            {
                CharacterId = model.CharacterId,
                MovieId = model.MovieId
            };
            using (var ctx = new ClassesDbContext())
            {
                ctx.CharacterMovies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies(int actorId)
        {
            //return list of movies where the actordId matches the movieIds in charactermovie that are tied to that actorId
            List < CharacterMovieListItem > characterMovies = GetCharacterMovieMovieIds(actorId);
            List<int> movieIds = GetMovieIdsFromList(characterMovies);

            using (var ctx = new ClassesDbContext())
            {
                var query = ctx
                    .Movies
                    .Where(e => movieIds.Contains(e.Id))
                    .Select(
                    e =>
                    new MovieListItem
                    {
                        Title = e.Title
                    }
                    );
                return query.ToArray();
            }
        }

        public List<CharacterMovieListItem> GetCharacterMovieMovieIds(int actorId)
        {
            //List<CharacterMovie> characterMovies = new List<CharacterMovie>();
            using (var ctx = new ClassesDbContext())
            {
                var query = ctx
                    .CharacterMovies
                    .Where(e => e.CharacterId == actorId)
                    .Select(
                    e =>
                    new CharacterMovieListItem
                    {
                        MovieId = e.MovieId,
                        CharacterId = e.CharacterId
                    }
                    );
                return query.ToList();
            }

        }

        public List<int> GetMovieIdsFromList(List<CharacterMovieListItem> characterMovies)
        {
            List<int> movieIds = new List<int>();
            foreach (CharacterMovieListItem characterMovie in characterMovies)
            {
                movieIds.Add(characterMovie.MovieId);
            }
            return movieIds;
        }

        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ClassesDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.Id == id);
                return
                    new CharacterDetail
                    {
                        RealName = entity.RealName,
                        AlterEgo = entity.AlterEgo,
                        Movies = GetMovies(id)
                    };
            }
        }

    }
}