import React, { useEffect, useState } from 'react';

/// functional component - allows adding a new tag
const AddNewTag = (props) => {
    const [form, setForm] = useState(null);
    const [newItemValue, setNewInputValue] = useState('');

    function onSubmit(event) {
        event.preventDefault();

        if (!newItemValue || props.tags.filter(e => e.name === newItemValue).length > 0) {
            return;
        }

        const trimValue = newItemValue.trim();

        if (trimValue.length) {
            props.addItem({ name: newItemValue, id: props.getMaxId() + 1 });
            setNewInputValue('');
        }
    }

    function onChange(e) {
        setNewInputValue(e.target.value);
    }

    return (
        <form onSubmit={onSubmit}>
            <div>
                <input type="text" placeholder="<new tag name>" value={newItemValue} onChange={onChange}/>
                <button type="submit">Add</button>
            </div>
        </form>
    );
}

export default AddNewTag;