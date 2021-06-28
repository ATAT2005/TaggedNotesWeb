import React from 'react';
import './../../custom.css';

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
                <td><button size="small" onClick={this.onClick}>X</button></td>
                <td>{this.props.text}</td>
                <td>{this.props.linkedTags}</td>
            </tr>
        );
    }
}