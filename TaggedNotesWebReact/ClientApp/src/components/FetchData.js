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
            <div width="100%">
                <table>
                    <tbody>
                        <tr>
                            <td width="75%" class="maintd">
                                <Notes items={notes} />
                            </td>
                            <td width="25%" class="maintd">
                                <Tags items={tags} />
                            </td>
                        </tr>
                    </tbody>
                </table>

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
                    <li class="strike">Show note list with linked tags</li>
                    <li class="strike">Show tag list</li>
                    <li class="strike">Allow user to add notes</li>
                    <li class="strike">Allow user to add tags</li>
                    <li class="strike">Allow user to delete notes</li>
                    <li class="strike">Allow user to delete tags</li>
                    <li class="strike">Allow user to save notes to DB</li>
                    <li class="strike">Allow user to save tags to DB</li>
                    <li class="strike">Allow user to filter notes by text</li>
                    <li class="strike">Allow user to filter tags by name</li>
                    <li>Center tags in column</li>
                    <li>Make common React component for Notes and List</li>
                    <li>Make common method for saving Notes and List simultaneously</li>
                    <li>Allow user to edit note text</li>
                    <li>Allow user to edit tag name</li>
                    <li>Allow user to link tags to notes</li>
                    <li>Allow user to mark tags with checks</li>
                    <li>Allow user to filter notes by checking tags</li>
                    <li>Prevent note text column from resizing after filtering</li>
                    <li>Prevent tag name column from resizing after filtering</li>
                    <li>Add highlight for hovered buttons</li>
                    <li>Add CSS classes for buttons, cells, headers</li>
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
