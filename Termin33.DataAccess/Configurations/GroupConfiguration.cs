using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Termin33.DataAccess.Entities;

namespace Termin33.DataAccess.Configurations
{
    /*
      
     korisnik(idGrupe) 1:m Grupa     //korisnik ima jednu grupu, grupa ima m (vise korisnika)
     korisnik m:1 porudzbina(idKorisnik) //korisnika ima m porudzbina vise porudzbina, a porudzbina ima jednog korisnika

     */


    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(g => g.Users) //grupa ima vise korisnika
                   .WithOne(u => u.Group) //jedan korisnik ima jednu grupu 
                   .HasForeignKey(u => u.GroupId).OnDelete(DeleteBehavior.Restrict); //referencira je preko spoljnog kljuca GroupId,
            //kad neko pokusa da obrise grupu koja ima korisnike desice se restrick operacija, 
            //da je cascade obrisali bi se svi korisnici koji su u toj grupi



        }
    }
}
