using System;
using System.Windows.Forms;

namespace PokemonGoMap
{
    public interface IMain
    {
        void BindSubForms(Func<Form> form, string text);
    }
}