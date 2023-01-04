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
        private TabDescription _description;

        private DirectoryTab _directoryTab;

        public Tab()
        {

        }

        public Tab(TabId id, TabName name, TabLink link, TabDescription description, DateTime created, string createdBy)
        {
            Id = id;
            _name = name;
            _link = link;
            _description = description;
            _created = created;
            _createdBy = createdBy;
        }

        public Tab(TabId id, TabName name, TabLink link, TabDescription description, DirectoryTab directoryTab, DateTime created, string createdBy)
        {
            Id = id;
            _name = name;
            _link = link;
            _description = description;
            _directoryTab = directoryTab;
            _created = created;
            _createdBy = createdBy;
        }

        public void Update(TabName? name = null, TabLink? link = null, TabDescription? description = null)
        {
            if (name is not null)
                EditName(name);

            if (link is not null)
                EditLink(link);

            if (description is not null)
                EditDescription(description);
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
            _description = newDescription;
        }
    }
}
