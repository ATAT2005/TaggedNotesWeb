import React from 'react';
import './../../custom.css';

export class TagItem extends React.Component {
    constructor(props) {
        super(props);
    }

    onClick = () => {
        this.props.removeItem(this.props.id);
    }

    render() {
        return (
            <tr>
                <td className="tagCell">{this.props.name}</td>
                <td><button onClick={this.onClick}>X</button></td>
            </tr>
        );
    }
}