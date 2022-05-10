using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Moderation Type Placeholder.")]
        Null,
        [Description("Relating to politics.")]
        Politics,
        [Description("Offensive language.")]
        Offensive,
        [Description("Illegal activities.")]
        Illicit,
        [Description("Displaying personal information.")]
        PersonalInformation,
        [Description("Hatred.")]
        Hatred
    }
}
