using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherUI.Shared;

namespace WeatherUI.Server.DAL.Schema;

public class PageViewItemScehma : IEntityTypeConfiguration<PageViewItem>
{
    public void Configure(EntityTypeBuilder<PageViewItem> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(new GuidToStringConverter());
    }
}
