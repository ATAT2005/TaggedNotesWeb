import React from 'react';
import './../../custom.css';

/// class component - a single note item
export class NoteItem extends React.Component {
    constructor(props) {
        super(props);
    }

    onClick = () => {
        this.props.removeItem(this.props.id);
    }

    render() {
        return (
            <tr>
                <td><button onClick={this.onClick}>X</button></td>
                <td className="noteCell">{this.props.text}</td>
                <td className="linkedTagsCell">{this.props.linkedTags}</td>
            </tr>
        );
    }
}