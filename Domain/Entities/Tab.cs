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

        private readonly ApplicationUser _owner;

        private Tab()
        {

        }

        internal Tab(TabId id, TabName name, TabLink link, TabDescription description, DirectoryTab directoryTab, DateTime created, string createdBy, ApplicationUser owner)
        {
            Id = id;
            _name = name;
            _link = link;
            _description = description;
            _directoryTab = directoryTab;
            _created = created;
            _createdBy = createdBy;
            _owner = owner;
        }

        public void Update(string? name = null, string? link = null, string? description = null)
        {
            if (!string.IsNullOrEmpty(name))
                EditName(name);

            if (!string.IsNullOrEmpty(link))
                EditLink(link);

            if (!string.IsNullOrEmpty(description))
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
