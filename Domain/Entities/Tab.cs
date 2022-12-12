using Domain.ValueObjects.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tab
    {
        public TabId Id { get; init; }

        private TabName _name;
        private TabLink _link;
        private TabDescription _descroption;
        private TabAuditable _audiatble;

        private DirectoryTab _directory;
        private Guid _directoryId;

        //Pozniej jeszcze będą zdjecia do dodania

        public Tab(TabId id, TabName name, TabLink link, TabDescription descroption, TabAuditable tabAuditable)
        {
            Id = id;
            _name = name;
            _link = link;
            _descroption = descroption;
            _audiatble = tabAuditable;
        }
    }
}
