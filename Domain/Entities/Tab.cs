using Domain.ValueObjects.Directory;
using Domain.ValueObjects.Tab;
using Shared.Abstractions.Auditables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tab : AggregateRoot
    {
        public TabId Id { get; private set; }

        private TabName _name;
        private TabLink _link;
        private TabDescription _descroption;

        private DirectoryTab _directoryTab;

        public Tab()
        {

        }

        public Tab(TabId id, TabName name, TabLink link, TabDescription descroption, DateTime created, string createdBy)
        {
            Id = id;
            _name = name;
            _link = link;
            _descroption = descroption;
            _created = created;
            _createdBy = createdBy;
        }

        public Tab(TabId id, TabName name, TabLink link, TabDescription descroption, DirectoryTab directoryTab, DateTime created, string createdBy)
        {
            Id = id;
            _name = name;
            _link = link;
            _descroption = descroption;
            _directoryTab = directoryTab;
            _created = created;
            _createdBy = createdBy;
        }

        public void Update(TabName? name = null, TabLink? link = null, TabDescription? descroption = null)
        {
            if (name is not null)
                EditName(name);

            if (link is not null)
                EditLink(link);

            if (descroption is not null)
                EditDescription(descroption);
        }

        private void EditName(TabName newName) 
        {
            _name = newName;
        }

        private void EditLink(TabLink newLink)
        {
            _link = newLink;
        }

        private void EditDescription(TabDescription newDescription)
        {
            _descroption = newDescription;
        }
    }
}
