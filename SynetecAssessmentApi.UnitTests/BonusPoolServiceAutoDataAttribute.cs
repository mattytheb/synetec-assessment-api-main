using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace SynetecAssessmentApi.UnitTests
{
    public class BonusPoolServiceAutoDataAttribute : DefaultAutoDataAttribute
    {
        public BonusPoolServiceAutoDataAttribute()
            : base(fixture => fixture.Customize(new BonusPoolServiceCustomisation()))
        {
        }
    }

    public class BonusPoolInlineAutoDataAttribute : InlineAutoDataAttribute
    { 
        public BonusPoolInlineAutoDataAttribute(params object[] objects) : base(new BonusPoolServiceAutoDataAttribute(), objects) { }
    }

    public class DefaultAutoDataAttribute : AutoDataAttribute
    {
        public DefaultAutoDataAttribute(Action<IFixture> fixtureAction, bool omitAutoProperties = false) : base(() =>
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization
            {
                ConfigureMembers = true
            });

            fixture.OmitAutoProperties = omitAutoProperties;

            fixtureAction.Invoke(fixture);

            return fixture;
        })
        {
        }
    }
}

