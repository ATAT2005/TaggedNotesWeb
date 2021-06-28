import React from 'react';
import { NoteList } from './NoteList';
import { AddNewNote } from './AddNewNote';

export class Notes extends React.Component {
    constructor(props) {
        super(props);
        this.state = { notes: props.items };

        this.saveNotes = this.saveNotes.bind(this);
    }

    addItem = note => {
        const newList = [...this.state.notes, note];
        this.setState({ notes: newList });
    }

    removeItem = id => {
        const newList = this.state.notes.filter(item => id !== item.id);
        this.setState({ notes: newList });
    }

    getCount = () => {
        return this.state.notes.length;
    }

    //todo: extract this method to a common method in a common component Editor (which will unite Notes and Tags components)
    saveNotes() {
        fetch('notes', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.state.notes)
        }).then(function (response) {
            console.log(response);
        })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return (
            <div>
                <button onClick={this.saveNotes}>Save notes</button>
                <AddNewNote addItem={this.addItem} getCount={this.getCount} />
                <NoteList items={this.state.notes} removeItem={this.removeItem} />
            </div>
        );
    }
}