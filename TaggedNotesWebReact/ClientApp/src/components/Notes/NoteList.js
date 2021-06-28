import React from 'react';
import { NoteItem } from './NoteItem';

export class NoteList extends React.Component {
    constructor(props) {
        super(props);

        this.state = { items: this.props.items };

        this.filterList = this.filterList.bind(this);
    }

    filterList(e) {
        var filteredList = this.props.items.filter(function (item) {
            return item.text.toLowerCase().search(e.target.value.toLowerCase()) !== -1;
        });
        
        this.setState({ items: filteredList });
    }

    render() {
        return (
            <div>
                <input placeholder="<filter notes>" onChange={this.filterList} />
                {
                    this.state.items.map(note => {
                        return <NoteItem
                            key={note.id}
                            id={note.id}
                            text={note.text}
                            linkedTags={note.linkedTags}
                            removeItem={this.props.removeItem} />
                    })
                }
            </div>);
    }
}