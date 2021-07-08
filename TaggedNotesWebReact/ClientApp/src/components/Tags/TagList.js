import React, { useEffect, useState } from 'react';
import TagItem from './TagItem';

/// functional component - a list of tags
const TagList = (props) => {

    const [items, setItems] = useState(props.items);

    const [filterValue, setFilterValue] = useState('');

    function filterList(e) {
        setFilterValue(e.target.value);

        var filteredList = props.items.filter(function (item) {
            return item.name.toLowerCase().search(e.target.value.toLowerCase()) !== -1;
        });

        setItems(filteredList);
    }

    useEffect(() => {
        setItems(props.items);
    }, [props.items])

    useEffect(() => {
        setFilterValue('');
    }, [props.items])

    return (
        <div>
            <input type="text" placeholder="<filter tags>" value={filterValue} onChange={filterList} />

            <table class="datatable">
                {
                    items.map(tag => {
                        return <TagItem
                            key={tag.id}
                            id={tag.id}
                            name={tag.name}
                            removeItem={props.removeItem}
                            updateItem={props.updateItem}
                        />
                    })
                }
            </table>
        </div>);
}

export default TagList;