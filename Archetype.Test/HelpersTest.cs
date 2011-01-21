using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Archetype;
using System.Data.Objects.DataClasses;

namespace Archetype.Test
{
    public class HelpersTest
    {
        [Fact]
        public void it_should_return_the_plural_of_a_simple_word()
        {
            Assert.Equal("monkeys", Helpers.Pluralize("monkey"));
        }

        [Fact]
        public void it_should_return_the_plural_of_a_not_so_simple_word()
        {
            Assert.Equal("women", Helpers.Pluralize("woman"));
        }

        [Fact]
        public void it_should_return_the_plural_of_a_type()
        {
            Foo f = new Foo();
            Assert.Equal("Foos", Helpers.Pluralize(f.GetType()));
        }

        [Fact]
        public void it_should_return_the_plural_of_an_object()
        {
            Foo f = new Foo();
            Assert.Equal("Foos", Helpers.Pluralize(f));
        }
    }

    class Foo : EntityObject
    {
    }
}
