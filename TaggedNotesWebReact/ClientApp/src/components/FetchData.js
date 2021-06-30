import React, { Component } from 'react';
import { Notes } from './Notes/Notes'
import { Tags } from './Tags/Tags'
import './../custom.css';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);

        this.state = {
            notes: [],
            tags: [],
            loading: true
        };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderEditor(notes, tags) {
        return (
            <div>
                <div align="center" class='parent flex-parent'>
                    <div class='child flex-notes'><Notes items={notes} /></div>
                    <div class='child flex-tags'><Tags items={tags} /></div>
                </div>

                <h2>Description</h2>
                <h5>
                    Editor for notes and their tags at the web page.<br />
                    In development.<br />
                    Each note can be linked with certain tags.<br />
                    Notes and tags can be filtered by text.<br />
                    Used technologies: ASP.NET Core MVC, Entity Framework Core, AutoMapper, React, NUnit, Moq<br />
                </h5>
                <h2>TODO:</h2>
                <ul>
                    <li class="strike">Show tags and notes list with linked tags</li>
                    <li class="strike">Allow user to add tags and notes</li>
                    <li class="strike">Allow user to delete tags and notes</li>
                    <li class="strike">Allow user to save tags and notes to DB</li>
                    <li class="strike">Allow user to filter tags and notes by text</li>
                    <li class="strike">Prevent adding note and tag with duplicate text</li>
                    <li class="strike">Prevent resizing tag and note column after filtering</li>
                    <li class="strike">Add CSS classes for cells</li>
                    <li class="strike">Reset filters after adding tag or note</li>
                    <li>Use hooks for storing state</li>
                    <li>Convert some components from classes to functional components</li>
                    <li>Make common React component for Notes and Tags</li>
                    <li>Make common method for saving Notes and Tags simultaneously</li>
                    <li>Allow user to edit note/tag text</li>
                    <li>Allow user to link tags to notes</li>
                    <li>Allow user to mark tags with checks</li>
                    <li>Allow user to filter notes by checking tags</li>
                    <li>Add highlight for hovered buttons</li>
                    <li>Add CSS classes for buttons</li>
                    <li>Add more unit tests</li>
                </ul>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderEditor(this.state.notes, this.state.tags);

        return (
            <div>
                <h1>Tagged Notes Web (React)</h1>
                {contents}
            </div>
        );
    }

    async populateData() {
        const responseNotes = await fetch('notes');
        const dataNotes = await responseNotes.json();
        const responseTags = await fetch('tags');
        const dataTags = await responseTags.json();
        this.setState({ notes: dataNotes, tags: dataTags, loading: false });
    }
}
