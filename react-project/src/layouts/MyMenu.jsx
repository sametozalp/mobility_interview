import { NavLink } from 'react-router-dom'
import { Menu, MenuItem } from 'semantic-ui-react'

export default function MyMenu() {
  return (
    <div>
      <div className='menu-item-title'>Entity</div>
      <Menu secondary vertical>
        <MenuItem as={NavLink} to="/entity/add" name='add' />
        <MenuItem as={NavLink} to="/entity/list" name='list' />
        <MenuItem as={NavLink} to="/entity/delete" name='delete' />
        <MenuItem  as={NavLink} to="/entity/search" name='search' />
      </Menu>

      <div className='spacer' />

      <div className='menu-item-title'>Web Service</div>
      <Menu secondary vertical>
        <MenuItem as={NavLink} to="/web/add" name='add' />
        <MenuItem as={NavLink} to="/web/list" name='list' />
        <MenuItem as={NavLink} to="/web/delete" name='delete' />
        <MenuItem  as={NavLink} to="/web/search" name='search' />
      </Menu>
    </div>
  )
}