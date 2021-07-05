import React from 'react';
import './../../custom.css';

/// functional component - a single tag item
 const TagItem = (props) => {
    function onClick() {
        props.removeItem(props.id);
    }

    return (
        <tr>
            <td className="tagCell">{props.name}</td>
            <td><button onClick={onClick}>X</button></td>
        </tr>
    );
}

export default TagItem;