import React from 'react';
import { NoteItem } from './NoteItem';

export class NoteList extends React.Component {
    constructor(props) {
        super(props);

        this.state = { items: this.props.items };

        this.filterList = this.filterList.bind(this);

        this.filterRef = React.createRef();
    }

    filterList(e) {
        var filteredList = this.props.items.filter(function (item) {
            return item.text.toLowerCase().search(e.target.value.toLowerCase()) !== -1;
        });
        
        this.setState({ items: filteredList });
    }

    componentWillReceiveProps(props) {
        this.setState({ items: props.items })
        this.filterRef.current.value = '';
    }

    render() {
        return (
            <div>
                <input placeholder="<filter notes>" ref={this.filterRef} onChange={this.filterList} />
                <table class="datatable">
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
                </table>
            </div>);
    }
}